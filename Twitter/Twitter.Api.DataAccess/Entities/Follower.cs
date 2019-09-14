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
			int id,
			string blocked,
			DateTime dateFollowed,
			int followedUserId,
			int followingUserId,
			string followRequestStatu,
			string muted)
		{
			this.Id = id;
			this.Blocked = blocked;
			this.DateFollowed = dateFollowed;
			this.FollowedUserId = followedUserId;
			this.FollowingUserId = followingUserId;
			this.FollowRequestStatu = followRequestStatu;
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
		public virtual User FollowedUserIdNavigation { get; private set; }

		public void SetFollowedUserIdNavigation(User item)
		{
			this.FollowedUserIdNavigation = item;
		}

		[ForeignKey("FollowingUserId")]
		public virtual User FollowingUserIdNavigation { get; private set; }

		public void SetFollowingUserIdNavigation(User item)
		{
			this.FollowingUserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>aaa609ed4e7a262dd55e9ed0fb2b6863</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/