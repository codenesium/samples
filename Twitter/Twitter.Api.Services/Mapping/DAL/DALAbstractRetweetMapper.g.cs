using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractRetweetMapper
	{
		public virtual Retweet MapBOToEF(
			BORetweet bo)
		{
			Retweet efRetweet = new Retweet();
			efRetweet.SetProperties(
				bo.Date,
				bo.Id,
				bo.RetwitterUserId,
				bo.Time,
				bo.TweetTweetId);
			return efRetweet;
		}

		public virtual BORetweet MapEFToBO(
			Retweet ef)
		{
			var bo = new BORetweet();

			bo.SetProperties(
				ef.Id,
				ef.Date,
				ef.RetwitterUserId,
				ef.Time,
				ef.TweetTweetId);
			return bo;
		}

		public virtual List<BORetweet> MapEFToBO(
			List<Retweet> records)
		{
			List<BORetweet> response = new List<BORetweet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>790d26f48eb98d6b8b598b588e8c9652</Hash>
</Codenesium>*/