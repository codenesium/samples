using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("sysdiagrams", Schema="dbo")]
	public partial class Sysdiagram : AbstractEntity
	{
		public Sysdiagram()
		{
		}

		public virtual void SetProperties(
			byte[] definition,
			int diagramId,
			string name,
			int principalId,
			int? version)
		{
			this.Definition = definition;
			this.DiagramId = diagramId;
			this.Name = name;
			this.PrincipalId = principalId;
			this.Version = version;
		}

		[MaxLength(1)]
		[Column("definition")]
		public byte[] Definition { get; private set; }

		[Key]
		[Column("diagram_id")]
		public int DiagramId { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("principal_id")]
		public int PrincipalId { get; private set; }

		[Column("version")]
		public int? Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2056b7148bf2b67012943b0de399e197</Hash>
</Codenesium>*/