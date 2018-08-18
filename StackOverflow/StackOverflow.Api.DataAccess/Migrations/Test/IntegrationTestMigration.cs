using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
	public class IntegrationTestMigration
	{
		private ApplicationDbContext context;

		public IntegrationTestMigration(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void Migrate()
		{
			var badgesItem1 = new Badges();
			badgesItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);
			this.context.Badges.Add(badgesItem1);

			var commentsItem1 = new Comments();
			commentsItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);
			this.context.Comments.Add(commentsItem1);

			var linkTypesItem1 = new LinkTypes();
			linkTypesItem1.SetProperties(1, "A");
			this.context.LinkTypes.Add(linkTypesItem1);

			var postHistoryItem1 = new PostHistory();
			postHistoryItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", "A", "A", 1);
			this.context.PostHistories.Add(postHistoryItem1);

			var postHistoryTypesItem1 = new PostHistoryTypes();
			postHistoryTypesItem1.SetProperties(1, "A");
			this.context.PostHistoryTypes.Add(postHistoryTypesItem1);

			var postLinksItem1 = new PostLinks();
			postLinksItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.context.PostLinks.Add(postLinksItem1);

			var postsItem1 = new Posts();
			postsItem1.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			this.context.Posts.Add(postsItem1);

			var postTypesItem1 = new PostTypes();
			postTypesItem1.SetProperties(1, "A");
			this.context.PostTypes.Add(postTypesItem1);

			var tagsItem1 = new Tags();
			tagsItem1.SetProperties(1, 1, 1, "A", 1);
			this.context.Tags.Add(tagsItem1);

			var usersItem1 = new Users();
			usersItem1.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			this.context.Users.Add(usersItem1);

			var votesItem1 = new Votes();
			votesItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.context.Votes.Add(votesItem1);

			var voteTypesItem1 = new VoteTypes();
			voteTypesItem1.SetProperties(1, "A");
			this.context.VoteTypes.Add(voteTypesItem1);

			this.context.SaveChanges();
		}
	}
}

/*<Codenesium>
    <Hash>6df5169173f3eb2c2367e17bf742b341</Hash>
</Codenesium>*/