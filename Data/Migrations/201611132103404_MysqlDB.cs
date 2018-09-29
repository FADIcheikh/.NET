namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MysqlDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Category", c => c.Int(nullable: false));
            AlterColumn("dbo.ReservationEvents", "IdSimpleUser", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReservationEvents", "IdSimpleUser", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Category");
        }
    }
}
