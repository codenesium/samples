using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("selfReference", Schema="dbo")]
	public partial class SelfReference : AbstractEntity
	{
		public SelfReference()
		{
		}

		public virtual void SetProperties(
			int id,
			int? selfReferenceId,
			int? selfReferenceId2)
		{
			this.Id = id;
			this.SelfReferenceId = selfReferenceId;
			this.SelfReferenceId2 = selfReferenceId2;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("selfReferenceId")]
		public int? SelfReferenceId { get; private set; }

		[Column("selfReferenceId2")]
		public int? SelfReferenceId2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c8005ee011b7091c99a4dd0b9e9c82cd</Hash>
</Codenesium>*/