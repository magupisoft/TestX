namespace MovieTest.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDescriptionLengthColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(maxLength: 100));
        }
    }
}
