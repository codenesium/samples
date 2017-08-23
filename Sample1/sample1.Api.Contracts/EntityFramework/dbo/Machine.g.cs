using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
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
    <Hash>4f57b8c7c619d65897d1c0bc3259da93</Hash>
</Codenesium>*/