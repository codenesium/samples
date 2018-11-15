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
		                                  int followedUserId,
		                                  int followingUserId,
		                                  string followRequestStatu,
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
    <Hash>bb6baad4bee2b60c5331faff4bc0f55c</Hash>
</Codenesium>*/