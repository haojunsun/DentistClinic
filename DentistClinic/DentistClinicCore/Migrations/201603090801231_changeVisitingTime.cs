namespace DentistClinic.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVisitingTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OutpatientCases", "VisitingTime", c => c.String());
            AlterColumn("dbo.OutpatientCases", "age", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OutpatientCases", "age", c => c.Int(nullable: false));
            AlterColumn("dbo.OutpatientCases", "VisitingTime", c => c.DateTime());
        }
    }
}
