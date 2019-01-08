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
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("selfReferenceId")]
		public virtual int? SelfReferenceId { get; private set; }

		[Column("selfReferenceId2")]
		public virtual int? SelfReferenceId2 { get; private set; }

		[ForeignKey("SelfReferenceId")]
		public virtual SelfReference SelfReference1Navigation { get; private set; }

		public void SetSelfReference1Navigation(SelfReference item)
		{
			this.SelfReference1Navigation = item;
		}

		[ForeignKey("SelfReferenceId2")]
		public virtual SelfReference SelfReference2Navigation { get; private set; }

		public void SetSelfReference2Navigation(SelfReference item)
		{
			this.SelfReference2Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a1e6955979b7a7aab7fe54dc8368e341</Hash>
</Codenesium>*/