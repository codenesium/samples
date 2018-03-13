using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Machine", Schema="dbo")]
	public partial class Machine
	{
		public Machine()
		{}

		public string description {get; set;}
		[Key]
		public int id {get; set;}
		public string jwtKey {get; set;}
		public string lastIpAddress {get; set;}
		public Guid machineGuid {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>8425443c241f65514d147b18536fc96f</Hash>
</Codenesium>*/