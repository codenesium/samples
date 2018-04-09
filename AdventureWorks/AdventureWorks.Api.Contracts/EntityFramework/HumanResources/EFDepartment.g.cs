using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Department", Schema="HumanResources")]
	public partial class EFDepartment
	{
		public EFDepartment()
		{}

		public void SetProperties(short departmentID,
		                          string name,
		                          string groupName,
		                          DateTime modifiedDate)
		{
			this.DepartmentID = departmentID;
			this.Name = name;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("DepartmentID", TypeName="smallint")]
		public short DepartmentID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("GroupName", TypeName="nvarchar(50)")]
		public string GroupName {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>fb32409c6f050d0848b83918dd7cd7a7</Hash>
</Codenesium>*/