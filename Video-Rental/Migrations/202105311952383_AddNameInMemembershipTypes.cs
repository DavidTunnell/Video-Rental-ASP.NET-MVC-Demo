namespace Video_Rental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameInMemembershipTypes : DbMigration
    {
        public override void Up()
        {
            //Generated via add-migration command with name being added to the MembershipTypes.cs model
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());


            //Populate via SQL
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
