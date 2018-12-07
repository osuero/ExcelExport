namespace PIP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DataSheets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Indicator = c.String(),
                        Functionality = c.String(),
                        Relavance = c.String(),
                        Feasibility = c.String(),
                        Periodicity = c.String(),
                        Metodología = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ranges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RangeID = c.Int(nullable: false),
                        Minimum = c.Int(nullable: false),
                        Maximum = c.Int(nullable: false),
                        ColorCode = c.String(),
                        LiteralText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RegionDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        Metropolitana = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CibaoNorte = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CibaoSur = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CibaoNordeste = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CibaoNoroeste = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Valdesia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Enriquillo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DelValle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Yuma = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Higuamo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TableInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CategoryId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TableInformations");
            DropTable("dbo.RegionDatas");
            DropTable("dbo.Ranges");
            DropTable("dbo.DataSheets");
            DropTable("dbo.Categories");
        }
    }
}
