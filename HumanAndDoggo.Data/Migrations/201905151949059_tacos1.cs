namespace HumanAndDoggo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tacos1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kennels", "DoggoName", c => c.String());
            AlterColumn("dbo.Kennels", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kennels", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.Kennels", "DoggoName", c => c.String(nullable: false));
        }
    }
}
