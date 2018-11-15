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
			int followedUserId,
			int followingUserId,
			string followRequestStatu,
			int id,
			string muted)
		{
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.FollowRequestStatu = followRequestStatu;
			this.Id = id;
			this.Muted = muted;
		}

		[MaxLength(1)]
		[Column("blocked")]
		public virtual string Blocked { get; private set; }

		[Column("date_followed")]
		public virtual DateTime DateFollowed { get; private set; }

		[MaxLength(1)]
		[Column("follow_request_status")]
		public virtual string FollowRequestStatu { get; private set; }

		[Column("followed_user_id")]
		public virtual int FollowedUserId { get; private set; }

		[Column("following_user_id")]
		public virtual int FollowingUserId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(1)]
		[Column("muted")]
		public virtual string Muted { get; private set; }

		[ForeignKey("FollowedUserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}

		[ForeignKey("FollowingUserId")]
		public virtual User User1Navigation { get; private set; }

		public void SetUser1Navigation(User item)
		{
			this.User1Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d475b9564dac19b33f7de294310be38a</Hash>
</Codenesium>*/