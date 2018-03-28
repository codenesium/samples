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
		public int id {get; set;}
		public string name {get; set;}
		public Guid machineGuid {get; set;}
		public string jwtKey {get; set;}
		public string lastIpAddress {get; set;}
		public string description {get; set;}
	}
}

/*<Codenesium>
    <Hash>2ca06c729754c1fc9ab7cab0f3473361</Hash>
</Codenesium>*/