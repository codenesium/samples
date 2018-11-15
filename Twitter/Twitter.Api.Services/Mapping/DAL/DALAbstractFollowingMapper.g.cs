using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractFollowingMapper
	{
		public virtual Following MapBOToEF(
			BOFollowing bo)
		{
			Following efFollowing = new Following();
			efFollowing.SetProperties(
				bo.DateFollowed,
				bo.Muted,
				bo.UserId);
			return efFollowing;
		}

		public virtual BOFollowing MapEFToBO(
			Following ef)
		{
			var bo = new BOFollowing();

			bo.SetProperties(
				ef.UserId,
				ef.DateFollowed,
				ef.Muted);
			return bo;
		}

		public virtual List<BOFollowing> MapEFToBO(
			List<Following> records)
		{
			List<BOFollowing> response = new List<BOFollowing>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c9e6f2dbe03b612adec36a1c1215cf74</Hash>
</Codenesium>*/