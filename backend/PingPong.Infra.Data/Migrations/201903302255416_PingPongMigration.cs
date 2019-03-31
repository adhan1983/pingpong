namespace PingPong.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PingPongMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FisrtName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(),
                        Email = c.String(),
                        SkillLevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillLevels", t => t.SkillLevelId, cascadeDelete: true)
                .Index(t => t.SkillLevelId);
            
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "SkillLevelId", "dbo.SkillLevels");
            DropIndex("dbo.Players", new[] { "SkillLevelId" });
            DropTable("dbo.SkillLevels");
            DropTable("dbo.Players");
        }
    }
}
