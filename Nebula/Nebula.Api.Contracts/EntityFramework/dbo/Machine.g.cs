using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Machine", Schema="dbo")]
	public partial class EFMachine
	{
		public EFMachine()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}
		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}
		[Column("machineGuid", TypeName="uniqueidentifier")]
		public Guid MachineGuid {get; set;}
		[Column("jwtKey", TypeName="varchar(128)")]
		public string JwtKey {get; set;}
		[Column("lastIpAddress", TypeName="varchar(128)")]
		public string LastIpAddress {get; set;}
		[Column("description", TypeName="text(2147483647)")]
		public string Description {get; set;}
	}
}

/*<Codenesium>
    <Hash>1486cfd9e238838dcaffdef35ebd318a</Hash>
</Codenesium>*/