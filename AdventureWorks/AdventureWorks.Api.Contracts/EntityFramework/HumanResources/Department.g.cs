using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Department", Schema="HumanResources")]
	public partial class EFDepartment
	{
		public EFDepartment()
		{}

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
    <Hash>0b91f1e430f666fbd02d9f49d40a90ca</Hash>
</Codenesium>*/