namespace DentistClinic.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OutpatientCases", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OutpatientCases", "Phone");
        }
    }
}
