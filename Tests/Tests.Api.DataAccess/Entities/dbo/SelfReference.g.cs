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
	}
}

/*<Codenesium>
    <Hash>b0996bdbb6c35cd9e3394fee09c5f8f6</Hash>
</Codenesium>*/