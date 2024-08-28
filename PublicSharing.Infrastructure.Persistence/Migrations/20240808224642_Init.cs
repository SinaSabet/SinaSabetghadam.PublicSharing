using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicSharing.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PublicTweet");

            migrationBuilder.CreateTable(
                name: "tweets",
                schema: "PublicTweet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tweets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "PublicTweet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HashTags",
                schema: "PublicTweet",
                columns: table => new
                {
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => new { x.TweetId, x.Id });
                    table.ForeignKey(
                        name: "FK_HashTags_tweets_TweetId",
                        column: x => x.TweetId,
                        principalSchema: "PublicTweet",
                        principalTable: "tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                schema: "PublicTweet",
                columns: table => new
                {
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.TweetId, x.Id });
                    table.ForeignKey(
                        name: "FK_Like_tweets_TweetId",
                        column: x => x.TweetId,
                        principalSchema: "PublicTweet",
                        principalTable: "tweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTweetIds",
                schema: "PublicTweet",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TweetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTweetIds", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserTweetIds_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "PublicTweet",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HashTags",
                schema: "PublicTweet");

            migrationBuilder.DropTable(
                name: "Like",
                schema: "PublicTweet");

            migrationBuilder.DropTable(
                name: "UserTweetIds",
                schema: "PublicTweet");

            migrationBuilder.DropTable(
                name: "tweets",
                schema: "PublicTweet");

            migrationBuilder.DropTable(
                name: "users",
                schema: "PublicTweet");
        }
    }
}
