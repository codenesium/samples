using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("Machine", Schema="dbo")]
	public partial class Machine : AbstractEntity
	{
		public Machine()
		{
		}

		public virtual void SetProperties(
			string description,
			int id,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description;
			this.Id = id;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		[MaxLength(2147483647)]
		[Column("description")]
		public string Description { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("jwtKey")]
		public string JwtKey { get; private set; }

		[MaxLength(128)]
		[Column("lastIpAddress")]
		public string LastIpAddress { get; private set; }

		[Column("machineGuid")]
		public Guid MachineGuid { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>49256a85b82d017f243485ee260fbfd4</Hash>
</Codenesium>*/