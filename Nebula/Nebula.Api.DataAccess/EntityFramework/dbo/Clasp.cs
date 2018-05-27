using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Clasp", Schema="dbo")]
	public partial class Clasp:AbstractEntityFrameworkDTO
	{
		public Clasp()
		{}

		public void SetProperties(
			int id,
			int nextChainId,
			int previousChainId)
		{
			this.Id = id.ToInt();
			this.NextChainId = nextChainId.ToInt();
			this.PreviousChainId = previousChainId.ToInt();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("nextChainId", TypeName="int")]
		public int NextChainId { get; set; }

		[Column("previousChainId", TypeName="int")]
		public int PreviousChainId { get; set; }

		[ForeignKey("NextChainId")]
		public virtual Chain Chain { get; set; }

		[ForeignKey("PreviousChainId")]
		public virtual Chain Chain1 { get; set; }
	}
}

/*<Codenesium>
    <Hash>722bcd7481420f7ec074072ce6326fd6</Hash>
</Codenesium>*/