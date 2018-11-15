using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractTweetMapper
	{
		public virtual Tweet MapBOToEF(
			BOTweet bo)
		{
			Tweet efTweet = new Tweet();
			efTweet.SetProperties(
				bo.Content,
				bo.Date,
				bo.LocationId,
				bo.Time,
				bo.TweetId,
				bo.UserUserId);
			return efTweet;
		}

		public virtual BOTweet MapEFToBO(
			Tweet ef)
		{
			var bo = new BOTweet();

			bo.SetProperties(
				ef.TweetId,
				ef.Content,
				ef.Date,
				ef.LocationId,
				ef.Time,
				ef.UserUserId);
			return bo;
		}

		public virtual List<BOTweet> MapEFToBO(
			List<Tweet> records)
		{
			List<BOTweet> response = new List<BOTweet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>80aabdf414a78a758ee9507f0550b1e7</Hash>
</Codenesium>*/