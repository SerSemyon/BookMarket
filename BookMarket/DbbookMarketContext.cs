using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookMarket;

public partial class DbbookMarketContext : DbContext
{
    public DbbookMarketContext()
    {
    }

    public DbbookMarketContext(DbContextOptions<DbbookMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<LegalEntity> LegalEntities { get; set; }

    public virtual DbSet<NodeAddressAccount> NodeAddressAccounts { get; set; }

    public virtual DbSet<NodeAuthorBook> NodeAuthorBooks { get; set; }

    public virtual DbSet<NodeGenreBook> NodeGenreBooks { get; set; }

    public virtual DbSet<NodeNphoneAccount> NodeNphoneAccounts { get; set; }

    public virtual DbSet<NodeOrderAccount> NodeOrderAccounts { get; set; }

    public virtual DbSet<NodeOrderBook> NodeOrderBooks { get; set; }

    public virtual DbSet<NumberPhone> NumberPhones { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderState> OrderStates { get; set; }

    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=DBBookMarket;User ID=postgres; Password=9988");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("account_pkey");

            entity.ToTable("account");

            entity.HasIndex(e => e.AccPhoneRegistration, "account_acc_phone_registration_key").IsUnique();

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccBirthday).HasColumnName("acc_birthday");
            entity.Property(e => e.AccEmail)
                .HasMaxLength(100)
                .HasColumnName("acc_email");
            entity.Property(e => e.AccGender)
                .HasMaxLength(1)
                .HasColumnName("acc_gender");
            entity.Property(e => e.AccHashPassword)
                .HasMaxLength(255)
                .HasColumnName("acc_hash_password");
            entity.Property(e => e.AccLastName)
                .HasMaxLength(100)
                .HasColumnName("acc_last_name");
            entity.Property(e => e.AccMiddleName)
                .HasMaxLength(100)
                .HasColumnName("acc_middle_name");
            entity.Property(e => e.AccName)
                .HasMaxLength(100)
                .HasColumnName("acc_name");
            entity.Property(e => e.AccPhoneRegistration)
                .HasMaxLength(11)
                .HasColumnName("acc_phone_registration");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_type_id_fkey");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("account_type_pkey");

            entity.ToTable("account_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(30)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("address_pkey");

            entity.ToTable("address");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AdrApartment).HasColumnName("adr_apartment");
            entity.Property(e => e.AdrCity)
                .HasMaxLength(100)
                .HasColumnName("adr_city");
            entity.Property(e => e.AdrEntrance).HasColumnName("adr_entrance");
            entity.Property(e => e.AdrFloor).HasColumnName("adr_floor");
            entity.Property(e => e.AdrHouse)
                .HasMaxLength(10)
                .HasColumnName("adr_house");
            entity.Property(e => e.AdrIsDefault)
                .HasDefaultValueSql("false")
                .HasColumnName("adr_is_default");
            entity.Property(e => e.AdrStreet)
                .HasMaxLength(100)
                .HasColumnName("adr_street");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("author_pkey");

            entity.ToTable("author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorDescription).HasColumnName("author_description");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(100)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("book_pkey");

            entity.ToTable("book");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BookAmount).HasColumnName("book_amount");
            entity.Property(e => e.BookDescription)
                .HasMaxLength(3000)
                .HasColumnName("book_description");
            entity.Property(e => e.BookImagePath).HasColumnName("book_image_path");
            entity.Property(e => e.BookName)
                .HasMaxLength(100)
                .HasColumnName("book_name");
            entity.Property(e => e.BookPrice)
                .HasPrecision(10, 2)
                .HasColumnName("book_price");
            entity.Property(e => e.BookRating)
                .HasPrecision(3, 2)
                .HasColumnName("book_rating");
            entity.Property(e => e.LegalEntityId).HasColumnName("legal_entity_id");
            entity.Property(e => e.PhouseId).HasColumnName("phouse_id");

            entity.HasOne(d => d.LegalEntity).WithMany(p => p.Books)
                .HasForeignKey(d => d.LegalEntityId)
                .HasConstraintName("book_legal_entity_id_fkey");

            entity.HasOne(d => d.Phouse).WithMany(p => p.Books)
                .HasForeignKey(d => d.PhouseId)
                .HasConstraintName("book_phouse_id_fkey");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("feedback_pkey");

            entity.ToTable("feedback");

            entity.Property(e => e.FeedbackId)
                .HasDefaultValueSql("nextval('feedback_person_id_seq'::regclass)")
                .HasColumnName("feedback_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.FbDescription)
                .HasMaxLength(3000)
                .HasColumnName("fb_description");
            entity.Property(e => e.FbIsAnonim)
                .HasDefaultValueSql("false")
                .HasColumnName("fb_is_anonim");
            entity.Property(e => e.FbRating)
                .HasPrecision(3, 2)
                .HasColumnName("fb_rating");

            entity.HasOne(d => d.Account).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("feedback_account_id_fkey");

            entity.HasOne(d => d.Book).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("feedback_book_id_fkey");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(100)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<LegalEntity>(entity =>
        {
            entity.HasKey(e => e.LegalEntityId).HasName("legal_entity_pkey");

            entity.ToTable("legal_entity");

            entity.Property(e => e.LegalEntityId).HasColumnName("legal_entity_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.DateRegistration).HasColumnName("date_registration");
            entity.Property(e => e.Psr)
                .HasMaxLength(13)
                .HasColumnName("psr");
            entity.Property(e => e.Tin)
                .HasMaxLength(12)
                .HasColumnName("tin");

            entity.HasOne(d => d.Account).WithMany(p => p.LegalEntities)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("legal_entity_account_id_fkey");
        });

        modelBuilder.Entity<NodeAddressAccount>(entity =>
        {
            entity.HasKey(e => e.NodeAddressAccountId).HasName("node_address_account_pkey");

            entity.ToTable("node_address_account");

            entity.Property(e => e.NodeAddressAccountId).HasColumnName("node_address_account_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");

            entity.HasOne(d => d.Account).WithMany(p => p.NodeAddressAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("node_address_account_account_id_fkey");

            entity.HasOne(d => d.Address).WithMany(p => p.NodeAddressAccounts)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("node_address_account_address_id_fkey");
        });

        modelBuilder.Entity<NodeAuthorBook>(entity =>
        {
            entity.HasKey(e => e.NodeAuthorBookId).HasName("node_author_book_pkey");

            entity.ToTable("node_author_book");

            entity.Property(e => e.NodeAuthorBookId).HasColumnName("node_author_book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");

            entity.HasOne(d => d.Author).WithMany(p => p.NodeAuthorBooks)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("node_author_book_author_id_fkey");

            entity.HasOne(d => d.Book).WithMany(p => p.NodeAuthorBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("node_author_book_book_id_fkey");
        });

        modelBuilder.Entity<NodeGenreBook>(entity =>
        {
            entity.HasKey(e => e.NodeGenreBookId).HasName("node_genre_book_pkey");

            entity.ToTable("node_genre_book");

            entity.Property(e => e.NodeGenreBookId).HasColumnName("node_genre_book_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.HasOne(d => d.Book).WithMany(p => p.NodeGenreBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("node_genre_book_book_id_fkey");

            entity.HasOne(d => d.Genre).WithMany(p => p.NodeGenreBooks)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("node_genre_book_genre_id_fkey");
        });

        modelBuilder.Entity<NodeNphoneAccount>(entity =>
        {
            entity.HasKey(e => e.NodeNphoneAccountId).HasName("node_nphone_account_pkey");

            entity.ToTable("node_nphone_account");

            entity.Property(e => e.NodeNphoneAccountId).HasColumnName("node_nphone_account_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.NphoneId).HasColumnName("nphone_id");

            entity.HasOne(d => d.Account).WithMany(p => p.NodeNphoneAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("node_nphone_account_account_id_fkey");

            entity.HasOne(d => d.Nphone).WithMany(p => p.NodeNphoneAccounts)
                .HasForeignKey(d => d.NphoneId)
                .HasConstraintName("node_nphone_account_np_phone_id_fkey");
        });

        modelBuilder.Entity<NodeOrderAccount>(entity =>
        {
            entity.HasKey(e => e.NodeOrderAccountId).HasName("node_order_account_pkey");

            entity.ToTable("node_order_account");

            entity.Property(e => e.NodeOrderAccountId).HasColumnName("node_order_account_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Account).WithMany(p => p.NodeOrderAccounts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("node_order_account_account_id_fkey");
        });

        modelBuilder.Entity<NodeOrderBook>(entity =>
        {
            entity.HasKey(e => e.NodeOrderBookId).HasName("node_order_book_pkey");

            entity.ToTable("node_order_book");

            entity.Property(e => e.NodeOrderBookId).HasColumnName("node_order_book_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Book).WithMany(p => p.NodeOrderBooks)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("node_order_book_book_id_fkey");
        });

        modelBuilder.Entity<NumberPhone>(entity =>
        {
            entity.HasKey(e => e.NphoneId).HasName("number_phone_pkey");

            entity.ToTable("number_phone");

            entity.Property(e => e.NphoneId)
                .HasDefaultValueSql("nextval('number_phone_np_phone_id_seq'::regclass)")
                .HasColumnName("nphone_id");
            entity.Property(e => e.NpIsDefault)
                .HasDefaultValueSql("false")
                .HasColumnName("np_is_default");
            entity.Property(e => e.NpPhone)
                .HasMaxLength(11)
                .HasColumnName("np_phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderAddressId).HasColumnName("order_address_id");
            entity.Property(e => e.OrderCreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("order_created_at");
            entity.Property(e => e.OrderDescription)
                .HasMaxLength(3000)
                .HasColumnName("order_description");
            entity.Property(e => e.OrderNphoneId).HasColumnName("order_nphone_id");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(20)
                .HasColumnName("order_number");
            entity.Property(e => e.OstateId).HasColumnName("ostate_id");

            entity.HasOne(d => d.Ostate).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OstateId)
                .HasConstraintName("orders_ostate_id_fkey");
        });

        modelBuilder.Entity<OrderState>(entity =>
        {
            entity.HasKey(e => e.OstateId).HasName("order_state_pkey");

            entity.ToTable("order_state");

            entity.Property(e => e.OstateId).HasColumnName("ostate_id");
            entity.Property(e => e.OstateDescription)
                .HasMaxLength(255)
                .HasColumnName("ostate_description");
            entity.Property(e => e.OstateName)
                .HasMaxLength(100)
                .HasColumnName("ostate_name");
        });

        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.HasKey(e => e.PhouseId).HasName("publishing_house_pkey");

            entity.ToTable("publishing_house");

            entity.Property(e => e.PhouseId).HasColumnName("phouse_id");
            entity.Property(e => e.PhDescription).HasColumnName("ph_description");
            entity.Property(e => e.PhName)
                .HasMaxLength(100)
                .HasColumnName("ph_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
