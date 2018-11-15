using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async void Migrate()
		{
			var directTweetItem1 = new DirectTweet();
			directTweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1);
			this.Context.DirectTweets.Add(directTweetItem1);

			var followerItem1 = new Follower();
			followerItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1, "A");
			this.Context.Followers.Add(followerItem1);

			var followingItem1 = new Following();
			followingItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.Context.Followings.Add(followingItem1);

			var locationItem1 = new Location();
			locationItem1.SetProperties(1, 1, 1, "A");
			this.Context.Locations.Add(locationItem1);

			var messageItem1 = new Message();
			messageItem1.SetProperties("A", 1, 1);
			this.Context.Messages.Add(messageItem1);

			var messengerItem1 = new Messenger();
			messengerItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			this.Context.Messengers.Add(messengerItem1);

			var quoteTweetItem1 = new QuoteTweet();
			quoteTweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("01:00:00"));
			this.Context.QuoteTweets.Add(quoteTweetItem1);

			var replyItem1 = new Reply();
			replyItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"));
			this.Context.Replies.Add(replyItem1);

			var retweetItem1 = new Retweet();
			retweetItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1);
			this.Context.Retweets.Add(retweetItem1);

			var tweetItem1 = new Tweet();
			tweetItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"), 1, 1);
			this.Context.Tweets.Add(tweetItem1);

			var userItem1 = new User();
			userItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", 1, "A", "A");
			this.Context.Users.Add(userItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>42c124473da4ebf2c64fc73d5af62a61</Hash>
</Codenesium>*/