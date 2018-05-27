using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Machine", Schema="dbo")]
	public partial class Machine: AbstractEntityFrameworkDTO
	{
		public Machine()
		{}

		public void SetProperties(
			int id,
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description;
			this.Id = id.ToInt();
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid.ToGuid();
			this.Name = name;
		}

		[Column("description", TypeName="text(2147483647)")]
		public string Description { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("jwtKey", TypeName="varchar(128)")]
		public string JwtKey { get; set; }

		[Column("lastIpAddress", TypeName="varchar(128)")]
		public string LastIpAddress { get; set; }

		[Column("machineGuid", TypeName="uniqueidentifier")]
		public Guid MachineGuid { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>d3313bd6eb70ac9e01791f04d96a446c</Hash>
</Codenesium>*/