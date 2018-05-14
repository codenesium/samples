using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Department", Schema="HumanResources")]
	public partial class Department: AbstractEntityFrameworkPOCO
	{
		public Department()
		{}

		public void SetProperties(
			short departmentID,
			string groupName,
			DateTime modifiedDate,
			string name)
		{
			this.DepartmentID = departmentID;
			this.GroupName = groupName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
		}

		[Key]
		[Column("DepartmentID", TypeName="smallint")]
		public short DepartmentID { get; set; }

		[Column("GroupName", TypeName="nvarchar(50)")]
		public string GroupName { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>8fcfe4dbc86322ce8a8e2a95538a5e2e</Hash>
</Codenesium>*/