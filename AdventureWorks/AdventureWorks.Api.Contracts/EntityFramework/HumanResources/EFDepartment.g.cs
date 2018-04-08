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
    <Hash>653c9b3d8d26edc7793dbfe5029d9eee</Hash>
</Codenesium>*/