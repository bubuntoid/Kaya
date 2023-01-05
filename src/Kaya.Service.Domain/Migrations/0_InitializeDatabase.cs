using FluentMigrator;

namespace Kaya.Service.Domain.Migrations;

[Migration(0)]
public class InitializeDatabaseMigration : Migration
{
    public override void Up()
    {
        Create.Table("user")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("login").AsString(64).NotNullable()
            .WithColumn("password").AsString(64).NotNullable()
            .WithColumn("name").AsString(64).NotNullable()
            .WithColumn("privateKey").AsString(64).NotNullable().Unique();

        Create.Table("project")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("userId").AsGuid().NotNullable().ForeignKey("user", "id")
            .WithColumn("name").AsString(64).NotNullable()
            .WithColumn("privateKey").AsString(64).NotNullable().Unique()
            .WithColumn("createdDate").AsDateTime().NotNullable();

        Create.Table("event")
            .WithColumn("id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("projectId").AsGuid().NotNullable().ForeignKey("project", "id")
            .WithColumn("message").AsString(2048).NotNullable()
            .WithColumn("date").AsDateTime().NotNullable()
            .WithColumn("tags").AsString(2048).NotNullable();

        Create.Table("eventContent")
            .WithColumn("eventId").AsGuid().NotNullable().PrimaryKey().ForeignKey("event", "id")
            .WithColumn("content").AsString().Nullable();
        
        Create.Table("eventHeader")
            .WithColumn("eventId").AsGuid().NotNullable().PrimaryKey().ForeignKey("event", "id")
            .WithColumn("key").AsString(254).NotNullable().PrimaryKey()
            .WithColumn("value").AsString(254).NotNullable();

        Create.Table("eventHeader")
            .WithColumn("eventId").AsGuid().NotNullable().PrimaryKey().ForeignKey("event", "id")
            .WithColumn("tag").AsString(254).NotNullable().PrimaryKey();
        
        Create.Table("projectEventTagSetting")
            .WithColumn("projectId").AsGuid().NotNullable().PrimaryKey().ForeignKey("project", "id")
            .WithColumn("tag").AsString(64).NotNullable().PrimaryKey()
            .WithColumn("style").AsString(64).NotNullable();
        
        Create.Table("systemEventTagSetting")
            .WithColumn("tag").AsString(64).NotNullable().PrimaryKey()
            .WithColumn("style").AsString(64).NotNullable();

        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Error", style = " " });
        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Warning", style = " " });
        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Success", style = " " });
        
        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Debug", style = " " });
        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Trace", style = " " });
        Insert.IntoTable("systemEventTagSetting").Row(new { tag = "Information", style = " " });

    }

    public override void Down()
    {
        
    }
}