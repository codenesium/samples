using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("LinkLog", Schema="dbo")]
	public partial class LinkLog: AbstractEntityFrameworkPOCO
	{
		public LinkLog()
		{}

		public void SetProperties(
			int id,
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.LinkId = linkId.ToInt();
			this.Log = log.ToString();
		}

		[Column("dateEntered", TypeName="datetime")]
		public DateTime DateEntered { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("linkId", TypeName="int")]
		public int LinkId { get; set; }

		[Column("log", TypeName="text(2147483647)")]
		public string Log { get; set; }

		[ForeignKey("LinkId")]
		public virtual Link Link { get; set; }
	}
}

/*<Codenesium>
    <Hash>c871ac8015c9c7dc61466f6abf0ff238</Hash>
</Codenesium>*/