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
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description.ToString();
			this.Id = id.ToInt();
			this.JwtKey = jwtKey.ToString();
			this.LastIpAddress = lastIpAddress.ToString();
			this.MachineGuid = machineGuid.ToGuid();
			this.Name = name.ToString();
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
    <Hash>e6ebd9dc6463530f026f8098522b954b</Hash>
</Codenesium>*/