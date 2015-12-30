namespace DentistClinic.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OutpatientCases", "AddTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OutpatientCases", "AddTime");
        }
    }
}
