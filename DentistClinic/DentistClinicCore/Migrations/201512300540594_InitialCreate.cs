namespace DentistClinic.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialCategories",
                c => new
                    {
                        MaterialCategoryId = c.Int(nullable: false, identity: true),
                        MaterialName = c.String(),
                    })
                .PrimaryKey(t => t.MaterialCategoryId);
            
            CreateTable(
                "dbo.MedicalCategories",
                c => new
                    {
                        MedicalCategoryId = c.Int(nullable: false, identity: true),
                        TeethUp = c.String(),
                        TeethDown = c.String(),
                        Diagnosis = c.String(),
                    })
                .PrimaryKey(t => t.MedicalCategoryId);
            
            CreateTable(
                "dbo.OutpatientCases",
                c => new
                    {
                        OutpatientCasesId = c.Int(nullable: false, identity: true),
                        VisitingTime = c.DateTime(),
                        Name = c.String(),
                        Sex = c.String(),
                        age = c.Int(nullable: false),
                        Complaint = c.String(),
                        MedicalHistory = c.String(),
                        TeethUp = c.String(),
                        TeethDown = c.String(),
                        CompleteTime = c.DateTime(),
                        IsWear = c.Boolean(nullable: false),
                        Address = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Checkup_MedicalCategoryId = c.Int(),
                        MaterialCategory_MaterialCategoryId = c.Int(),
                        Treatment_MedicalCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.OutpatientCasesId)
                .ForeignKey("dbo.MedicalCategories", t => t.Checkup_MedicalCategoryId)
                .ForeignKey("dbo.MaterialCategories", t => t.MaterialCategory_MaterialCategoryId)
                .ForeignKey("dbo.MedicalCategories", t => t.Treatment_MedicalCategoryId)
                .Index(t => t.Checkup_MedicalCategoryId)
                .Index(t => t.MaterialCategory_MaterialCategoryId)
                .Index(t => t.Treatment_MedicalCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OutpatientCases", "Treatment_MedicalCategoryId", "dbo.MedicalCategories");
            DropForeignKey("dbo.OutpatientCases", "MaterialCategory_MaterialCategoryId", "dbo.MaterialCategories");
            DropForeignKey("dbo.OutpatientCases", "Checkup_MedicalCategoryId", "dbo.MedicalCategories");
            DropIndex("dbo.OutpatientCases", new[] { "Treatment_MedicalCategoryId" });
            DropIndex("dbo.OutpatientCases", new[] { "MaterialCategory_MaterialCategoryId" });
            DropIndex("dbo.OutpatientCases", new[] { "Checkup_MedicalCategoryId" });
            DropTable("dbo.OutpatientCases");
            DropTable("dbo.MedicalCategories");
            DropTable("dbo.MaterialCategories");
        }
    }
}
