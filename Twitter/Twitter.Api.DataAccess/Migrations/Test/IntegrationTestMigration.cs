using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async void Migrate()
		{
			var directTweetItem1 = new DirectTweet();
			directTweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1);
			this.context.DirectTweets.Add(directTweetItem1);

			var followingItem1 = new Following();
			followingItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			this.context.Followings.Add(followingItem1);

			var likeItem1 = new Like();
			likeItem1.SetProperties(1, 1, 1);
			this.context.Likes.Add(likeItem1);

			var locationItem1 = new Location();
			locationItem1.SetProperties(1, 1, 1, "A");
			this.context.Locations.Add(locationItem1);

			var messageItem1 = new Message();
			messageItem1.SetProperties("A", 1, 1);
			this.context.Messages.Add(messageItem1);

			var messengerItem1 = new Messenger();
			messengerItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"), 1, 1);
			this.context.Messengers.Add(messengerItem1);

			var quoteTweetItem1 = new QuoteTweet();
			quoteTweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"));
			this.context.QuoteTweets.Add(quoteTweetItem1);

			var replyItem1 = new Reply();
			replyItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));
			this.context.Replies.Add(replyItem1);

			var retweetItem1 = new Retweet();
			retweetItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1);
			this.context.Retweets.Add(retweetItem1);

			var tweetItem1 = new Tweet();
			tweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"), 1, 1);
			this.context.Tweets.Add(tweetItem1);

			var userItem1 = new User();
			userItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", 1, "A", "A");
			this.context.Users.Add(userItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>1686a25205deadd4d9c3b836a1f90dce</Hash>
</Codenesium>*/