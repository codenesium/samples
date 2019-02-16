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
			int id,
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.Id = id;
			this.DateEntered = dateEntered;
			this.LinkId = linkId;
			this.Log = log;
		}

		[Column("dateEntered")]
		public virtual DateTime DateEntered { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("linkId")]
		public virtual int LinkId { get; private set; }

		[MaxLength(2147483647)]
		[Column("log")]
		public virtual string Log { get; private set; }

		[ForeignKey("LinkId")]
		public virtual Link LinkIdNavigation { get; private set; }

		public void SetLinkIdNavigation(Link item)
		{
			this.LinkIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>5525a5bcfe423a521cd8e13a7ae265d7</Hash>
</Codenesium>*/