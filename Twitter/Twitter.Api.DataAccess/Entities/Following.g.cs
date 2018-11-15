using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Following", Schema="dbo")]
	public partial class Following : AbstractEntity
	{
		public Following()
		{
		}

		public virtual void SetProperties(
			DateTime? dateFollowed,
			string muted,
			int userId)
		{
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
			this.UserId = userId;
		}

		[Column("date_followed")]
		public virtual DateTime? DateFollowed { get; private set; }

		[MaxLength(1)]
		[Column("muted")]
		public virtual string Muted { get; private set; }

		[Key]
		[Column("user_id")]
		public virtual int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c1e7918efa58a4445ba078d27f8d211e</Hash>
</Codenesium>*/