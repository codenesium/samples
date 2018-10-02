using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractDirectTweetMapper
	{
		public virtual DirectTweet MapBOToEF(
			BODirectTweet bo)
		{
			DirectTweet efDirectTweet = new DirectTweet();
			efDirectTweet.SetProperties(
				bo.Content,
				bo.Date,
				bo.TaggedUserId,
				bo.Time,
				bo.TweetId);
			return efDirectTweet;
		}

		public virtual BODirectTweet MapEFToBO(
			DirectTweet ef)
		{
			var bo = new BODirectTweet();

			bo.SetProperties(
				ef.TweetId,
				ef.Content,
				ef.Date,
				ef.TaggedUserId,
				ef.Time);
			return bo;
		}

		public virtual List<BODirectTweet> MapEFToBO(
			List<DirectTweet> records)
		{
			List<BODirectTweet> response = new List<BODirectTweet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>495b0f0df3f25f78f415d545dcf3b3ec</Hash>
</Codenesium>*/