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
			string userId)
		{
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
			this.UserId = userId;
		}

		[Column("date_followed")]
		public DateTime? DateFollowed { get; private set; }

		[MaxLength(1)]
		[Column("muted")]
		public string Muted { get; private set; }

		[Key]
		[MaxLength(64)]
		[Column("user_id")]
		public string UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>98122b438a6c697bb8a5b4cd5d34de83</Hash>
</Codenesium>*/