using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookMarket.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "account_type",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_type_pkey", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    adr_city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    adr_street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    adr_house = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    adr_entrance = table.Column<int>(type: "integer", nullable: true),
                    adr_floor = table.Column<int>(type: "integer", nullable: true),
                    adr_apartment = table.Column<int>(type: "integer", nullable: true),
                    adr_is_default = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("address_pkey", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    author_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("author_pkey", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre_pkey", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "number_phone",
                columns: table => new
                {
                    nphone_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('number_phone_np_phone_id_seq'::regclass)"),
                    np_phone = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    np_is_default = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("number_phone_pkey", x => x.nphone_id);
                });

            migrationBuilder.CreateTable(
                name: "order_state",
                columns: table => new
                {
                    ostate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ostate_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ostate_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_state_pkey", x => x.ostate_id);
                });

            migrationBuilder.CreateTable(
                name: "publishing_house",
                columns: table => new
                {
                    phouse_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ph_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ph_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("publishing_house_pkey", x => x.phouse_id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    acc_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    acc_last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    acc_middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    acc_gender = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    acc_birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    acc_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    acc_phone_registration = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    acc_hash_password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("account_pkey", x => x.account_id);
                    table.ForeignKey(
                        name: "account_type_id_fkey",
                        column: x => x.type_id,
                        principalTable: "account_type",
                        principalColumn: "type_id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ostate_id = table.Column<int>(type: "integer", nullable: true),
                    order_description = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    order_address_id = table.Column<int>(type: "integer", nullable: true),
                    order_nphone_id = table.Column<int>(type: "integer", nullable: true),
                    order_created_at = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("orders_pkey", x => x.order_id);
                    table.ForeignKey(
                        name: "orders_ostate_id_fkey",
                        column: x => x.ostate_id,
                        principalTable: "order_state",
                        principalColumn: "ostate_id");
                });

            migrationBuilder.CreateTable(
                name: "legal_entity",
                columns: table => new
                {
                    legal_entity_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LegalName = table.Column<string>(type: "text", nullable: true),
                    account_id = table.Column<int>(type: "integer", nullable: true),
                    date_registration = table.Column<DateOnly>(type: "date", nullable: true),
                    psr = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    tin = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("legal_entity_pkey", x => x.legal_entity_id);
                    table.ForeignKey(
                        name: "legal_entity_account_id_fkey",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "node_address_account",
                columns: table => new
                {
                    node_address_account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address_id = table.Column<int>(type: "integer", nullable: true),
                    account_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_address_account_pkey", x => x.node_address_account_id);
                    table.ForeignKey(
                        name: "node_address_account_account_id_fkey",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "node_address_account_address_id_fkey",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id");
                });

            migrationBuilder.CreateTable(
                name: "node_nphone_account",
                columns: table => new
                {
                    node_nphone_account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nphone_id = table.Column<int>(type: "integer", nullable: true),
                    account_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_nphone_account_pkey", x => x.node_nphone_account_id);
                    table.ForeignKey(
                        name: "node_nphone_account_account_id_fkey",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "node_nphone_account_np_phone_id_fkey",
                        column: x => x.nphone_id,
                        principalTable: "number_phone",
                        principalColumn: "nphone_id");
                });

            migrationBuilder.CreateTable(
                name: "node_order_account",
                columns: table => new
                {
                    node_order_account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: true),
                    account_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_order_account_pkey", x => x.node_order_account_id);
                    table.ForeignKey(
                        name: "node_order_account_account_id_fkey",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    legal_entity_id = table.Column<int>(type: "integer", nullable: true),
                    book_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phouse_id = table.Column<int>(type: "integer", nullable: true),
                    book_amount = table.Column<int>(type: "integer", nullable: false),
                    book_price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    book_rating = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: true),
                    book_description = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    book_image_path = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("book_pkey", x => x.book_id);
                    table.ForeignKey(
                        name: "book_legal_entity_id_fkey",
                        column: x => x.legal_entity_id,
                        principalTable: "legal_entity",
                        principalColumn: "legal_entity_id");
                    table.ForeignKey(
                        name: "book_phouse_id_fkey",
                        column: x => x.phouse_id,
                        principalTable: "publishing_house",
                        principalColumn: "phouse_id");
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('feedback_person_id_seq'::regclass)"),
                    book_id = table.Column<int>(type: "integer", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false),
                    fb_is_anonim = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false"),
                    fb_description = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    fb_rating = table.Column<decimal>(type: "numeric(3,2)", precision: 3, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("feedback_pkey", x => x.feedback_id);
                    table.ForeignKey(
                        name: "feedback_account_id_fkey",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "account_id");
                    table.ForeignKey(
                        name: "feedback_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "node_author_book",
                columns: table => new
                {
                    node_author_book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: true),
                    book_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_author_book_pkey", x => x.node_author_book_id);
                    table.ForeignKey(
                        name: "node_author_book_author_id_fkey",
                        column: x => x.author_id,
                        principalTable: "author",
                        principalColumn: "author_id");
                    table.ForeignKey(
                        name: "node_author_book_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateTable(
                name: "node_genre_book",
                columns: table => new
                {
                    node_genre_book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre_id = table.Column<int>(type: "integer", nullable: true),
                    book_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_genre_book_pkey", x => x.node_genre_book_id);
                    table.ForeignKey(
                        name: "node_genre_book_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "node_genre_book_genre_id_fkey",
                        column: x => x.genre_id,
                        principalTable: "genre",
                        principalColumn: "genre_id");
                });

            migrationBuilder.CreateTable(
                name: "node_order_book",
                columns: table => new
                {
                    node_order_book_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<int>(type: "integer", nullable: true),
                    book_id = table.Column<int>(type: "integer", nullable: true),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("node_order_book_pkey", x => x.node_order_book_id);
                    table.ForeignKey(
                        name: "node_order_book_book_id_fkey",
                        column: x => x.book_id,
                        principalTable: "book",
                        principalColumn: "book_id");
                });

            migrationBuilder.CreateIndex(
                name: "account_acc_phone_registration_key",
                table: "account",
                column: "acc_phone_registration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_type_id",
                table: "account",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_legal_entity_id",
                table: "book",
                column: "legal_entity_id");

            migrationBuilder.CreateIndex(
                name: "IX_book_phouse_id",
                table: "book",
                column: "phouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_account_id",
                table: "feedback",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_book_id",
                table: "feedback",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_legal_entity_account_id",
                table: "legal_entity",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_address_account_account_id",
                table: "node_address_account",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_address_account_address_id",
                table: "node_address_account",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_author_book_author_id",
                table: "node_author_book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_author_book_book_id",
                table: "node_author_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_genre_book_book_id",
                table: "node_genre_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_genre_book_genre_id",
                table: "node_genre_book",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_nphone_account_account_id",
                table: "node_nphone_account",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_nphone_account_nphone_id",
                table: "node_nphone_account",
                column: "nphone_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_order_account_account_id",
                table: "node_order_account",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_node_order_book_book_id",
                table: "node_order_book",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ostate_id",
                table: "orders",
                column: "ostate_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "node_address_account");

            migrationBuilder.DropTable(
                name: "node_author_book");

            migrationBuilder.DropTable(
                name: "node_genre_book");

            migrationBuilder.DropTable(
                name: "node_nphone_account");

            migrationBuilder.DropTable(
                name: "node_order_account");

            migrationBuilder.DropTable(
                name: "node_order_book");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "number_phone");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "order_state");

            migrationBuilder.DropTable(
                name: "legal_entity");

            migrationBuilder.DropTable(
                name: "publishing_house");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "account_type");
        }
    }
}
