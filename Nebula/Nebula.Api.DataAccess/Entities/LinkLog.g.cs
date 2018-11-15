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
		public virtual Link LinkNavigation { get; private set; }

		public void SetLinkNavigation(Link item)
		{
			this.LinkNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>59a131106a7353d12adafa8dfd85a3a4</Hash>
</Codenesium>*/