using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
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
				bo.FollowRequestStatu,
				bo.FollowedUserId,
				bo.FollowingUserId,
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
				ef.FollowRequestStatu,
				ef.FollowedUserId,
				ef.FollowingUserId,
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
    <Hash>9242e840f47e8d37e33aacc7ec21a9d7</Hash>
</Codenesium>*/