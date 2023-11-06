using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BookMarket
{
    public class Program
    {
        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        
        public static string HashPassword(string password)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return ByteArrayToString(tmpHash);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddAuthentication("Bearer").AddCookie();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/accessdenied";
                });

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".MyApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthorization();            // ���������� �������� �����������

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapGet("/accessdenied", async (HttpContext context) =>
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Access Denied");
            });

            app.MapGet("/login", async (HttpContext context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                // html-����� ��� ����� ������/������
                string loginForm = @"<!DOCTYPE html>
                    <html>
                    <head>
                        <meta charset='utf-8' />
                        <title>�����������</title>
                    </head>
                    <body>
                        <h2>�����������</h2>
                        <form method='post'>
                            <p>
                                <label>����� ��������</label><br />
                                <input name='phone_number' />
                            </p>
                            <p>
                                <label>������</label><br />
                                <input type='password' name='password' />
                            </p>
                            <input type='submit' value='���������' />
                        </form>
                    </body>
                    </html>";
                    await context.Response.WriteAsync(loginForm);
            });

            app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
            {
                DbbookMarketContext db = new DbbookMarketContext();
                // �������� �� ����� phone_number � ������
                var form = context.Request.Form;
                // ���� phone_number �/��� ������ �� �����������, �������� ��������� ��� ������ 400
                if (!form.ContainsKey("phone_number") || !form.ContainsKey("password"))
                    return Results.BadRequest("����� �������� �/��� ������ �� �����������");
                string phone_number = form["phone_number"];
                string password = form["password"];
                string hashPassword = HashPassword(password);

                // ������� ������������ 
                Account? person = db.Accounts.FirstOrDefault(p => (p.AccPhoneRegistration == phone_number) && (p.AccHashPassword == hashPassword));
                // ���� ������������ �� ������, ���������� ��������� ��� 401
                if (person is null) return Results.Redirect("/login");
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, person.AccPhoneRegistration),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.TypeId.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await context.SignInAsync(claimsPrincipal);
                return Results.Redirect(returnUrl ?? "/");
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSession();

            app.Run();
        }
    }
}