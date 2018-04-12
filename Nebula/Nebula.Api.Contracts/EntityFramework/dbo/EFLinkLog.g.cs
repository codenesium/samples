using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.Contracts
{
	[Table("LinkLog", Schema="dbo")]
	public partial class EFLinkLog
	{
		public EFLinkLog()
		{}

		public void SetProperties(
			int id,
			int linkId,
			string log,
			DateTime dateEntered)
		{
			this.Id = id.ToInt();
			this.LinkId = linkId.ToInt();
			this.Log = log;
			this.DateEntered = dateEntered.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("linkId", TypeName="int")]
		public int LinkId { get; set; }

		[Column("log", TypeName="text(2147483647)")]
		public string Log { get; set; }

		[Column("dateEntered", TypeName="datetime")]
		public DateTime DateEntered { get; set; }

		[ForeignKey("LinkId")]
		public virtual EFLink Link { get; set; }
	}
}

/*<Codenesium>
    <Hash>cabbd4cf05b495e33cb0a83d26b0c3e7</Hash>
</Codenesium>*/