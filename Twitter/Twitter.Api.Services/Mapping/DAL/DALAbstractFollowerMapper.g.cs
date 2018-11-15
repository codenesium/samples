using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractFollowerMapper
	{
		public virtual Follower MapBOToEF(
			BOFollower bo)
		{
			Follower efFollower = new Follower();
			efFollower.SetProperties(
				bo.Blocked,
				bo.DateFollowed,
				bo.FollowedUserId,
				bo.FollowingUserId,
				bo.FollowRequestStatu,
				bo.Id,
				bo.Muted);
			return efFollower;
		}

		public virtual BOFollower MapEFToBO(
			Follower ef)
		{
			var bo = new BOFollower();

			bo.SetProperties(
				ef.Id,
				ef.Blocked,
				ef.DateFollowed,
				ef.FollowedUserId,
				ef.FollowingUserId,
				ef.FollowRequestStatu,
				ef.Muted);
			return bo;
		}

		public virtual List<BOFollower> MapEFToBO(
			List<Follower> records)
		{
			List<BOFollower> response = new List<BOFollower>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0469c456af2a15e2636741c7667ee434</Hash>
</Codenesium>*/