using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    <Hash>b66293613f6522ed564adccec4486026</Hash>
</Codenesium>*/