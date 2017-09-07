using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
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
    <Hash>15495e0393ed2067f8708299d35f629c</Hash>
</Codenesium>*/