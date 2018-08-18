using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("LinkLog", Schema="dbo")]
	public partial class LinkLog : AbstractEntity
	{
		public LinkLog()
		{
		}

		public virtual void SetProperties(
			DateTime dateEntered,
			int id,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered;
			this.Id = id;
			this.LinkId = linkId;
			this.Log = log;
		}

		[Column("dateEntered")]
		public DateTime DateEntered { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("linkId")]
		public int LinkId { get; private set; }

		[MaxLength(2147483647)]
		[Column("log")]
		public string Log { get; private set; }

		[ForeignKey("LinkId")]
		public virtual Link LinkNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>190ceaa86ab686f688e13e4c87e45f2c</Hash>
</Codenesium>*/