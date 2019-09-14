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
		public virtual SelfReference SelfReferenceIdNavigation { get; private set; }

		public void SetSelfReferenceIdNavigation(SelfReference item)
		{
			this.SelfReferenceIdNavigation = item;
		}

		[ForeignKey("SelfReferenceId2")]
		public virtual SelfReference SelfReferenceId2Navigation { get; private set; }

		public void SetSelfReferenceId2Navigation(SelfReference item)
		{
			this.SelfReferenceId2Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f1c9397be50aca1320ffbdb995758296</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/