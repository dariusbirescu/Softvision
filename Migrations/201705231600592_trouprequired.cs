namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trouprequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TroupTypes", "Name", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TroupTypes", "Name", c => c.String());
        }
    }
}
