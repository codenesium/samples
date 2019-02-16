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
			int id,
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Id = id;
			this.Description = description;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		[MaxLength(2147483647)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("jwtKey")]
		public virtual string JwtKey { get; private set; }

		[MaxLength(128)]
		[Column("lastIpAddress")]
		public virtual string LastIpAddress { get; private set; }

		[Column("machineGuid")]
		public virtual Guid MachineGuid { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9da9e97c15f7bf00f4b4f3c64934e727</Hash>
</Codenesium>*/