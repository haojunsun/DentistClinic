namespace DentistClinic.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teeth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OutpatientCases", "Checkup_MedicalCategoryId", "dbo.MedicalCategories");
            DropForeignKey("dbo.OutpatientCases", "Treatment_MedicalCategoryId", "dbo.MedicalCategories");
            DropIndex("dbo.OutpatientCases", new[] { "Checkup_MedicalCategoryId" });
            DropIndex("dbo.OutpatientCases", new[] { "Treatment_MedicalCategoryId" });
            AddColumn("dbo.OutpatientCases", "Checkup", c => c.String());
            AddColumn("dbo.OutpatientCases", "Treatment", c => c.String());
            AddColumn("dbo.OutpatientCases", "TeethUpLeft", c => c.String());
            AddColumn("dbo.OutpatientCases", "TeethUpRight", c => c.String());
            AddColumn("dbo.OutpatientCases", "TeethDownLeft", c => c.String());
            AddColumn("dbo.OutpatientCases", "TeethDownRight", c => c.String());
            DropColumn("dbo.OutpatientCases", "TeethUp");
            DropColumn("dbo.OutpatientCases", "TeethDown");
            DropColumn("dbo.OutpatientCases", "Checkup_MedicalCategoryId");
            DropColumn("dbo.OutpatientCases", "Treatment_MedicalCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OutpatientCases", "Treatment_MedicalCategoryId", c => c.Int());
            AddColumn("dbo.OutpatientCases", "Checkup_MedicalCategoryId", c => c.Int());
            AddColumn("dbo.OutpatientCases", "TeethDown", c => c.String());
            AddColumn("dbo.OutpatientCases", "TeethUp", c => c.String());
            DropColumn("dbo.OutpatientCases", "TeethDownRight");
            DropColumn("dbo.OutpatientCases", "TeethDownLeft");
            DropColumn("dbo.OutpatientCases", "TeethUpRight");
            DropColumn("dbo.OutpatientCases", "TeethUpLeft");
            DropColumn("dbo.OutpatientCases", "Treatment");
            DropColumn("dbo.OutpatientCases", "Checkup");
            CreateIndex("dbo.OutpatientCases", "Treatment_MedicalCategoryId");
            CreateIndex("dbo.OutpatientCases", "Checkup_MedicalCategoryId");
            AddForeignKey("dbo.OutpatientCases", "Treatment_MedicalCategoryId", "dbo.MedicalCategories", "MedicalCategoryId");
            AddForeignKey("dbo.OutpatientCases", "Checkup_MedicalCategoryId", "dbo.MedicalCategories", "MedicalCategoryId");
        }
    }
}
