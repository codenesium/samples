using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("LinkLog", Schema="dbo")]
	public partial class LinkLog: AbstractEntity
	{
		public LinkLog()
		{}

		public void SetProperties(
			DateTime dateEntered,
			int id,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.LinkId = linkId.ToInt();
			this.Log = log;
		}

		[Column("dateEntered", TypeName="datetime")]
		public DateTime DateEntered { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("linkId", TypeName="int")]
		public int LinkId { get; private set; }

		[Column("log", TypeName="text(2147483647)")]
		public string Log { get; private set; }

		[ForeignKey("LinkId")]
		public virtual Link Link { get; set; }
	}
}

/*<Codenesium>
    <Hash>0f3839cca99694b1623498b641ddebcc</Hash>
</Codenesium>*/