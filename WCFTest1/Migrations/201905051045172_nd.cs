namespace WCFTest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameRatings");
        }
    }
}
