namespace HumanAndDoggo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doggoes",
                c => new
                    {
                        DoggoID = c.Int(nullable: false, identity: true),
                        DoggoName = c.String(),
                        Breed = c.String(),
                        Size = c.Int(nullable: false),
                        HumanID = c.Int(nullable: false),
                        DoggoFriendly = c.Boolean(nullable: false),
                        PeopleFriendly = c.Boolean(nullable: false),
                        SpecialNeeds = c.String(),
                        Age = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.DoggoID)
                .ForeignKey("dbo.Humen", t => t.HumanID, cascadeDelete: true)
                .Index(t => t.HumanID);
            
            CreateTable(
                "dbo.Humen",
                c => new
                    {
                        HumanID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.HumanID);
            
            CreateTable(
                "dbo.Kennels",
                c => new
                    {
                        KennelID = c.Int(nullable: false, identity: true),
                        KennelNumber = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Occupied = c.Boolean(nullable: false),
                        DoggoID = c.Int(nullable: false),
                        DoggoName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Human_HumanID = c.Int(),
                    })
                .PrimaryKey(t => t.KennelID)
                .ForeignKey("dbo.Doggoes", t => t.DoggoID, cascadeDelete: true)
                .ForeignKey("dbo.Humen", t => t.Human_HumanID)
                .Index(t => t.DoggoID)
                .Index(t => t.Human_HumanID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Kennels", "Human_HumanID", "dbo.Humen");
            DropForeignKey("dbo.Kennels", "DoggoID", "dbo.Doggoes");
            DropForeignKey("dbo.Doggoes", "HumanID", "dbo.Humen");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Kennels", new[] { "Human_HumanID" });
            DropIndex("dbo.Kennels", new[] { "DoggoID" });
            DropIndex("dbo.Doggoes", new[] { "HumanID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Kennels");
            DropTable("dbo.Humen");
            DropTable("dbo.Doggoes");
        }
    }
}
