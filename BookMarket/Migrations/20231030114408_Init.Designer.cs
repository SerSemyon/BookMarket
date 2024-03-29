﻿// <auto-generated />
using System;
using BookMarket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookMarket.Migrations
{
    [DbContext(typeof(DbbookMarketContext))]
    [Migration("20231030114408_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "adminpack");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookMarket.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountId"));

                    b.Property<DateOnly?>("AccBirthday")
                        .HasColumnType("date")
                        .HasColumnName("acc_birthday");

                    b.Property<string>("AccEmail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("acc_email");

                    b.Property<string>("AccGender")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("acc_gender");

                    b.Property<string>("AccHashPassword")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("acc_hash_password");

                    b.Property<string>("AccLastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("acc_last_name");

                    b.Property<string>("AccMiddleName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("acc_middle_name");

                    b.Property<string>("AccName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("acc_name");

                    b.Property<string>("AccPhoneRegistration")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("acc_phone_registration");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    b.HasKey("AccountId")
                        .HasName("account_pkey");

                    b.HasIndex("TypeId");

                    b.HasIndex(new[] { "AccPhoneRegistration" }, "account_acc_phone_registration_key")
                        .IsUnique();

                    b.ToTable("account", (string)null);
                });

            modelBuilder.Entity("BookMarket.AccountType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("type_name");

                    b.HasKey("TypeId")
                        .HasName("account_type_pkey");

                    b.ToTable("account_type", (string)null);
                });

            modelBuilder.Entity("BookMarket.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("address_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<int?>("AdrApartment")
                        .HasColumnType("integer")
                        .HasColumnName("adr_apartment");

                    b.Property<string>("AdrCity")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("adr_city");

                    b.Property<int?>("AdrEntrance")
                        .HasColumnType("integer")
                        .HasColumnName("adr_entrance");

                    b.Property<int?>("AdrFloor")
                        .HasColumnType("integer")
                        .HasColumnName("adr_floor");

                    b.Property<string>("AdrHouse")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("adr_house");

                    b.Property<bool?>("AdrIsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("adr_is_default")
                        .HasDefaultValueSql("false");

                    b.Property<string>("AdrStreet")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("adr_street");

                    b.HasKey("AddressId")
                        .HasName("address_pkey");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("BookMarket.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorDescription")
                        .HasColumnType("text")
                        .HasColumnName("author_description");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("author_name");

                    b.HasKey("AuthorId")
                        .HasName("author_pkey");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("BookMarket.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookId"));

                    b.Property<int>("BookAmount")
                        .HasColumnType("integer")
                        .HasColumnName("book_amount");

                    b.Property<string>("BookDescription")
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)")
                        .HasColumnName("book_description");

                    b.Property<string>("BookImagePath")
                        .HasColumnType("text")
                        .HasColumnName("book_image_path");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("book_name");

                    b.Property<decimal>("BookPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("book_price");

                    b.Property<decimal?>("BookRating")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("book_rating");

                    b.Property<int?>("LegalEntityId")
                        .HasColumnType("integer")
                        .HasColumnName("legal_entity_id");

                    b.Property<int?>("PhouseId")
                        .HasColumnType("integer")
                        .HasColumnName("phouse_id");

                    b.HasKey("BookId")
                        .HasName("book_pkey");

                    b.HasIndex("LegalEntityId");

                    b.HasIndex("PhouseId");

                    b.ToTable("book", (string)null);
                });

            modelBuilder.Entity("BookMarket.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("feedback_id")
                        .HasDefaultValueSql("nextval('feedback_person_id_seq'::regclass)");

                    b.Property<int>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<string>("FbDescription")
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)")
                        .HasColumnName("fb_description");

                    b.Property<bool?>("FbIsAnonim")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("fb_is_anonim")
                        .HasDefaultValueSql("false");

                    b.Property<decimal?>("FbRating")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("fb_rating");

                    b.HasKey("FeedbackId")
                        .HasName("feedback_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookId");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("BookMarket.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("genre_name");

                    b.HasKey("GenreId")
                        .HasName("genre_pkey");

                    b.ToTable("genre", (string)null);
                });

            modelBuilder.Entity("BookMarket.LegalEntity", b =>
                {
                    b.Property<int>("LegalEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("legal_entity_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LegalEntityId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<DateOnly?>("DateRegistration")
                        .HasColumnType("date")
                        .HasColumnName("date_registration");

                    b.Property<string>("LegalName")
                        .HasColumnType("text");

                    b.Property<string>("Psr")
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("psr");

                    b.Property<string>("Tin")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)")
                        .HasColumnName("tin");

                    b.HasKey("LegalEntityId")
                        .HasName("legal_entity_pkey");

                    b.HasIndex("AccountId");

                    b.ToTable("legal_entity", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeAddressAccount", b =>
                {
                    b.Property<int>("NodeAddressAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_address_account_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeAddressAccountId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer")
                        .HasColumnName("address_id");

                    b.HasKey("NodeAddressAccountId")
                        .HasName("node_address_account_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("AddressId");

                    b.ToTable("node_address_account", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeAuthorBook", b =>
                {
                    b.Property<int>("NodeAuthorBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_author_book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeAuthorBookId"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.HasKey("NodeAuthorBookId")
                        .HasName("node_author_book_pkey");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("node_author_book", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeGenreBook", b =>
                {
                    b.Property<int>("NodeGenreBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_genre_book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeGenreBookId"));

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int?>("GenreId")
                        .HasColumnType("integer")
                        .HasColumnName("genre_id");

                    b.HasKey("NodeGenreBookId")
                        .HasName("node_genre_book_pkey");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("node_genre_book", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeNphoneAccount", b =>
                {
                    b.Property<int>("NodeNphoneAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_nphone_account_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeNphoneAccountId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int?>("NphoneId")
                        .HasColumnType("integer")
                        .HasColumnName("nphone_id");

                    b.HasKey("NodeNphoneAccountId")
                        .HasName("node_nphone_account_pkey");

                    b.HasIndex("AccountId");

                    b.HasIndex("NphoneId");

                    b.ToTable("node_nphone_account", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeOrderAccount", b =>
                {
                    b.Property<int>("NodeOrderAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_order_account_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeOrderAccountId"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.HasKey("NodeOrderAccountId")
                        .HasName("node_order_account_pkey");

                    b.HasIndex("AccountId");

                    b.ToTable("node_order_account", (string)null);
                });

            modelBuilder.Entity("BookMarket.NodeOrderBook", b =>
                {
                    b.Property<int>("NodeOrderBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("node_order_book_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NodeOrderBookId"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<int?>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.HasKey("NodeOrderBookId")
                        .HasName("node_order_book_pkey");

                    b.HasIndex("BookId");

                    b.ToTable("node_order_book", (string)null);
                });

            modelBuilder.Entity("BookMarket.NumberPhone", b =>
                {
                    b.Property<int>("NphoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("nphone_id")
                        .HasDefaultValueSql("nextval('number_phone_np_phone_id_seq'::regclass)");

                    b.Property<bool?>("NpIsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasColumnName("np_is_default")
                        .HasDefaultValueSql("false");

                    b.Property<string>("NpPhone")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("np_phone");

                    b.HasKey("NphoneId")
                        .HasName("number_phone_pkey");

                    b.ToTable("number_phone", (string)null);
                });

            modelBuilder.Entity("BookMarket.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("OrderAddressId")
                        .HasColumnType("integer")
                        .HasColumnName("order_address_id");

                    b.Property<DateOnly?>("OrderCreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("order_created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("OrderDescription")
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)")
                        .HasColumnName("order_description");

                    b.Property<int?>("OrderNphoneId")
                        .HasColumnType("integer")
                        .HasColumnName("order_nphone_id");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("order_number");

                    b.Property<int?>("OstateId")
                        .HasColumnType("integer")
                        .HasColumnName("ostate_id");

                    b.HasKey("OrderId")
                        .HasName("orders_pkey");

                    b.HasIndex("OstateId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("BookMarket.OrderState", b =>
                {
                    b.Property<int>("OstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ostate_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OstateId"));

                    b.Property<string>("OstateDescription")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ostate_description");

                    b.Property<string>("OstateName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ostate_name");

                    b.HasKey("OstateId")
                        .HasName("order_state_pkey");

                    b.ToTable("order_state", (string)null);
                });

            modelBuilder.Entity("BookMarket.PublishingHouse", b =>
                {
                    b.Property<int>("PhouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("phouse_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PhouseId"));

                    b.Property<string>("PhDescription")
                        .HasColumnType("text")
                        .HasColumnName("ph_description");

                    b.Property<string>("PhName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("ph_name");

                    b.HasKey("PhouseId")
                        .HasName("publishing_house_pkey");

                    b.ToTable("publishing_house", (string)null);
                });

            modelBuilder.Entity("BookMarket.Account", b =>
                {
                    b.HasOne("BookMarket.AccountType", "Type")
                        .WithMany("Accounts")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("account_type_id_fkey");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BookMarket.Book", b =>
                {
                    b.HasOne("BookMarket.LegalEntity", "LegalEntity")
                        .WithMany("Books")
                        .HasForeignKey("LegalEntityId")
                        .HasConstraintName("book_legal_entity_id_fkey");

                    b.HasOne("BookMarket.PublishingHouse", "Phouse")
                        .WithMany("Books")
                        .HasForeignKey("PhouseId")
                        .HasConstraintName("book_phouse_id_fkey");

                    b.Navigation("LegalEntity");

                    b.Navigation("Phouse");
                });

            modelBuilder.Entity("BookMarket.Feedback", b =>
                {
                    b.HasOne("BookMarket.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("feedback_account_id_fkey");

                    b.HasOne("BookMarket.Book", "Book")
                        .WithMany("Feedbacks")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("feedback_book_id_fkey");

                    b.Navigation("Account");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookMarket.LegalEntity", b =>
                {
                    b.HasOne("BookMarket.Account", "Account")
                        .WithMany("LegalEntities")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("legal_entity_account_id_fkey");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BookMarket.NodeAddressAccount", b =>
                {
                    b.HasOne("BookMarket.Account", "Account")
                        .WithMany("NodeAddressAccounts")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("node_address_account_account_id_fkey");

                    b.HasOne("BookMarket.Address", "Address")
                        .WithMany("NodeAddressAccounts")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("node_address_account_address_id_fkey");

                    b.Navigation("Account");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BookMarket.NodeAuthorBook", b =>
                {
                    b.HasOne("BookMarket.Author", "Author")
                        .WithMany("NodeAuthorBooks")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("node_author_book_author_id_fkey");

                    b.HasOne("BookMarket.Book", "Book")
                        .WithMany("NodeAuthorBooks")
                        .HasForeignKey("BookId")
                        .HasConstraintName("node_author_book_book_id_fkey");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookMarket.NodeGenreBook", b =>
                {
                    b.HasOne("BookMarket.Book", "Book")
                        .WithMany("NodeGenreBooks")
                        .HasForeignKey("BookId")
                        .HasConstraintName("node_genre_book_book_id_fkey");

                    b.HasOne("BookMarket.Genre", "Genre")
                        .WithMany("NodeGenreBooks")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("node_genre_book_genre_id_fkey");

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookMarket.NodeNphoneAccount", b =>
                {
                    b.HasOne("BookMarket.Account", "Account")
                        .WithMany("NodeNphoneAccounts")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("node_nphone_account_account_id_fkey");

                    b.HasOne("BookMarket.NumberPhone", "Nphone")
                        .WithMany("NodeNphoneAccounts")
                        .HasForeignKey("NphoneId")
                        .HasConstraintName("node_nphone_account_np_phone_id_fkey");

                    b.Navigation("Account");

                    b.Navigation("Nphone");
                });

            modelBuilder.Entity("BookMarket.NodeOrderAccount", b =>
                {
                    b.HasOne("BookMarket.Account", "Account")
                        .WithMany("NodeOrderAccounts")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("node_order_account_account_id_fkey");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BookMarket.NodeOrderBook", b =>
                {
                    b.HasOne("BookMarket.Book", "Book")
                        .WithMany("NodeOrderBooks")
                        .HasForeignKey("BookId")
                        .HasConstraintName("node_order_book_book_id_fkey");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookMarket.Order", b =>
                {
                    b.HasOne("BookMarket.OrderState", "Ostate")
                        .WithMany("Orders")
                        .HasForeignKey("OstateId")
                        .HasConstraintName("orders_ostate_id_fkey");

                    b.Navigation("Ostate");
                });

            modelBuilder.Entity("BookMarket.Account", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("LegalEntities");

                    b.Navigation("NodeAddressAccounts");

                    b.Navigation("NodeNphoneAccounts");

                    b.Navigation("NodeOrderAccounts");
                });

            modelBuilder.Entity("BookMarket.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BookMarket.Address", b =>
                {
                    b.Navigation("NodeAddressAccounts");
                });

            modelBuilder.Entity("BookMarket.Author", b =>
                {
                    b.Navigation("NodeAuthorBooks");
                });

            modelBuilder.Entity("BookMarket.Book", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("NodeAuthorBooks");

                    b.Navigation("NodeGenreBooks");

                    b.Navigation("NodeOrderBooks");
                });

            modelBuilder.Entity("BookMarket.Genre", b =>
                {
                    b.Navigation("NodeGenreBooks");
                });

            modelBuilder.Entity("BookMarket.LegalEntity", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookMarket.NumberPhone", b =>
                {
                    b.Navigation("NodeNphoneAccounts");
                });

            modelBuilder.Entity("BookMarket.OrderState", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BookMarket.PublishingHouse", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
