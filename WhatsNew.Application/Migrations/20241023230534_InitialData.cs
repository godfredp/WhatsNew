using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsNew.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			// Insert seed data for RoleGroups
			migrationBuilder.InsertData(
				table: "RoleGroups",
				columns: new[] { "Id", "Name", "Rank" },
				values: new object[,]
				{
				{ 1, "Internal", 1 }, // You can adjust Id and Rank values accordingly
                { 2, "External", 2 }
				});

			// Insert seed data for RoleTags
			migrationBuilder.InsertData(
				table: "RoleTags",
				columns: new[] { "Id", "RoleGroupId", "Name" },
				values: new object[,]
				{
				{ 1, 1, "Recruiter" }, // Recruiter belongs to RoleGroup with Id 1 (Internal)
                { 2, 1, "Placement Supervisor" }, // Placement Supervisor also belongs to Internal
				{ 3, 2, "Customer" }
				});

			// Insert seed data for Users
			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "RoleTagId", "FirstName", "LastName", "IsNew","ArcadeAuthentication" },
				values: new object[,]
				{
				{ 1, 1, "Sam", "Pichon", true, "" },
                { 2, 1, "Joe", "Arnaiz", false, "" },
				{ 3, 2, "Joie", "Gonzales",false, "" },
				{ 4, 3, "Shain", "Esmajer", true, "" },
				});

			// Insert seed data for Topic Groups
			migrationBuilder.InsertData(
				table: "TopicGroup",
				columns: new[] { "Id", "RoleGroupId", "Name"},
				values: new object[,]
				{
				{ 1, 1, "Recruitment"},
				{ 2, 1, "Job Openings"},
				{ 3, 1, "Active Pool"},
				{ 4, 2, "Customer Portal"},
				});

			// Insert seed data for Topic Groups
			migrationBuilder.InsertData(
				table: "TopicTags",
				columns: new[] { "Id", "TopicGroupId", "Name" },
				values: new object[,]
				{
				{ 1, 1, "Applicants"},
				{ 2, 1, "Leads"},
				{ 3, 2, "Endorsements"},
				{ 4, 2, "JO Status"},
				{ 5, 3, "Hot Levels"},
				{ 6, 4, "Request Interviews"},
				});

			// Insert seed data for Topic Groups
			migrationBuilder.InsertData(
				table: "ActionTypes",
				columns: new[] { "Id", "Action" },
				values: new object[,]
				{
				{ 1, "Click"},
				{ 2, "Text Input"},
				{ 3, "Navigate"},
				});

			// Insert seed data for Topic Groups
			migrationBuilder.InsertData(
				table: "Features",
				columns: new[] { "Id", "RoleTagId", "TopicTagId", "IsMajor", "Author" },
				values: new object[,]
				{
				{ 1, 1, 1, true, "Sam Pichon"}, // Recruiter + Applicants
				{ 2, 1, 2, false, "Sam Pichon"}, // Recruiter + Leads
				{ 3, 2, 3, false, "Joe Arnaiz"}, // Placement Supervisor + Endorsements
				});

			// Insert seed data for Topic Groups
			migrationBuilder.InsertData(
				table: "SubFeatures",
				columns: new[] { "Id", "FeatureId", "Text", "VideoUrl" },
				values: new object[,]
				{
				{ 1, 1, "<b>Applicants Test Onlyyy</b>", string.Empty}, // Recruiter + Applicants
				{ 2, 1, "<b>We Added new Features for Applicants!</b>", string.Empty}, // Recruiter + Applicants 2
				{ 3, 2, "<b>Leads Test Only</b>", string.Empty},
				{ 4, 3, "<b>Endorsements Test Only and only for supervisors!</b>", string.Empty},
				});
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
