using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.Contracts
{
	[Table("Machine", Schema="dbo")]
	public partial class EFMachine
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
			this.Name = name;
			this.MachineGuid = machineGuid;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.Description = description;
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
    <Hash>0956193d666ab676ebd8e89397f4d29e</Hash>
</Codenesium>*/