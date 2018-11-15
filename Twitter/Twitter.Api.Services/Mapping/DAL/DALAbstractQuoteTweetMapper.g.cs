using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractQuoteTweetMapper
	{
		public virtual QuoteTweet MapBOToEF(
			BOQuoteTweet bo)
		{
			QuoteTweet efQuoteTweet = new QuoteTweet();
			efQuoteTweet.SetProperties(
				bo.Content,
				bo.Date,
				bo.QuoteTweetId,
				bo.RetweeterUserId,
				bo.SourceTweetId,
				bo.Time);
			return efQuoteTweet;
		}

		public virtual BOQuoteTweet MapEFToBO(
			QuoteTweet ef)
		{
			var bo = new BOQuoteTweet();

			bo.SetProperties(
				ef.QuoteTweetId,
				ef.Content,
				ef.Date,
				ef.RetweeterUserId,
				ef.SourceTweetId,
				ef.Time);
			return bo;
		}

		public virtual List<BOQuoteTweet> MapEFToBO(
			List<QuoteTweet> records)
		{
			List<BOQuoteTweet> response = new List<BOQuoteTweet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2895198e9e807980608eddba193e9aa4</Hash>
</Codenesium>*/