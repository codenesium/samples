using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOFollower : AbstractBusinessObject
	{
		public AbstractBOFollower()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string blocked,
		                                  DateTime dateFollowed,
		                                  string followRequestStatu,
		                                  int followedUserId,
		                                  int followingUserId,
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

		public string Blocked { get; private set; }

		public DateTime DateFollowed { get; private set; }

		public string FollowRequestStatu { get; private set; }

		public int FollowedUserId { get; private set; }

		public int FollowingUserId { get; private set; }

		public int Id { get; private set; }

		public string Muted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>84d60778c59d8eb28c7876c66eb534f3</Hash>
</Codenesium>*/