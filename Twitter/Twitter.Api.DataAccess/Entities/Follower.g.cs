using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Follower", Schema="dbo")]
	public partial class Follower : AbstractEntity
	{
		public Follower()
		{
		}

		public virtual void SetProperties(
			string blocked,
			DateTime dateFollowed,
			string followRequestStatu,
			int followedUserId,
			int followingUserId,
			int id,
			string muted)
		{
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowRequestStatu = followRequestStatu;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.Id = id;
			this.Muted = muted;
		}

		[MaxLength(1)]
		[Column("blocked")]
		public string Blocked { get; private set; }

		[Column("date_followed")]
		public DateTime DateFollowed { get; private set; }

		[MaxLength(1)]
		[Column("follow_request_status")]
		public string FollowRequestStatu { get; private set; }

		[Column("followed_user_id")]
		public int FollowedUserId { get; private set; }

		[Column("following_user_id")]
		public int FollowingUserId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(1)]
		[Column("muted")]
		public string Muted { get; private set; }

		[ForeignKey("FollowedUserId")]
		public virtual User UserNavigation { get; private set; }

		[ForeignKey("FollowingUserId")]
		public virtual User User1Navigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>50d2c218db355e9af84c00de5615481c</Hash>
</Codenesium>*/