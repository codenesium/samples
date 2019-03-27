using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("sysdiagrams", Schema="dbo")]
	public partial class Sysdiagrams : AbstractEntity
	{
		public Sysdiagrams()
		{
		}

		public virtual void SetProperties(
			int diagramId,
			byte[] definition,
			string name,
			int principalId,
			int? version)
		{
			this.DiagramId = diagramId;
			this.Definition = definition;
			this.Name = name;
			this.PrincipalId = principalId;
			this.Version = version;
		}

		[MaxLength(1)]
		[Column("definition")]
		public virtual byte[] Definition { get; private set; }

		[Key]
		[Column("diagram_id")]
		public virtual int DiagramId { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("principal_id")]
		public virtual int PrincipalId { get; private set; }

		[Column("version")]
		public virtual int? Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3dff045fecaa50e9ddfd78e5b59c97f6</Hash>
</Codenesium>*/