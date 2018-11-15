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
    <Hash>bd814ab08386935679c77c4904d2d465</Hash>
</Codenesium>*/