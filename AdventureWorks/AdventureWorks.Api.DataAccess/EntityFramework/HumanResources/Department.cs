using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Department", Schema="HumanResources")]
	public partial class Department: AbstractEntityFrameworkDTO
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
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
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
    <Hash>2b8b34ee906d037a8f1a3be7f982f1f6</Hash>
</Codenesium>*/