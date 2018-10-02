using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractLikeMapper
	{
		public virtual Like MapBOToEF(
			BOLike bo)
		{
			Like efLike = new Like();
			efLike.SetProperties(
				bo.LikeId,
				bo.LikerUserId,
				bo.TweetId);
			return efLike;
		}

		public virtual BOLike MapEFToBO(
			Like ef)
		{
			var bo = new BOLike();

			bo.SetProperties(
				ef.LikeId,
				ef.LikerUserId,
				ef.TweetId);
			return bo;
		}

		public virtual List<BOLike> MapEFToBO(
			List<Like> records)
		{
			List<BOLike> response = new List<BOLike>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>44b0ccf13188e5d423ded5fe2b508cfa</Hash>
</Codenesium>*/