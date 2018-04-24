using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Machine", Schema="dbo")]
	public partial class EFMachine: AbstractEntityFrameworkPOCO
	{
		public EFMachine()
		{}

		public void SetProperties(
			int id,
			string name,
			Guid machineGuid,
			string jwtKey,
			string lastIpAddress,
			string description)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.MachineGuid = machineGuid.ToGuid();
			this.JwtKey = jwtKey.ToString();
			this.LastIpAddress = lastIpAddress.ToString();
			this.Description = description.ToString();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("machineGuid", TypeName="uniqueidentifier")]
		public Guid MachineGuid { get; set; }

		[Column("jwtKey", TypeName="varchar(128)")]
		public string JwtKey { get; set; }

		[Column("lastIpAddress", TypeName="varchar(128)")]
		public string LastIpAddress { get; set; }

		[Column("description", TypeName="text(2147483647)")]
		public string Description { get; set; }
	}
}

/*<Codenesium>
    <Hash>be2cf386adcc5f16b4fea4e571f9f3d6</Hash>
</Codenesium>*/