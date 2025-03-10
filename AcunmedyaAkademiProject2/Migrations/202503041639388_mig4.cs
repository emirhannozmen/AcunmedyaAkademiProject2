namespace AcunmedyaAkademiProject2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        InfoId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.InfoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
