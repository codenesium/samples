using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var badgesItem1 = new Badges();
			badgesItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.Context.Badges.Add(badgesItem1);

			var commentsItem1 = new Comments();
			commentsItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			this.Context.Comments.Add(commentsItem1);

			var linkTypesItem1 = new LinkTypes();
			linkTypesItem1.SetProperties(1, "A");
			this.Context.LinkTypes.Add(linkTypesItem1);

			var postHistoryItem1 = new PostHistory();
			postHistoryItem1.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			this.Context.PostHistory.Add(postHistoryItem1);

			var postHistoryTypesItem1 = new PostHistoryTypes();
			postHistoryTypesItem1.SetProperties(1, "A");
			this.Context.PostHistoryTypes.Add(postHistoryTypesItem1);

			var postLinksItem1 = new PostLinks();
			postLinksItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			this.Context.PostLinks.Add(postLinksItem1);

			var postsItem1 = new Posts();
			postsItem1.SetProperties(1, 1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			this.Context.Posts.Add(postsItem1);

			var postTypesItem1 = new PostTypes();
			postTypesItem1.SetProperties(1, "A");
			this.Context.PostTypes.Add(postTypesItem1);

			var tagsItem1 = new Tags();
			tagsItem1.SetProperties(1, 1, 1, "A", 1);
			this.Context.Tags.Add(tagsItem1);

			var usersItem1 = new Users();
			usersItem1.SetProperties(1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			this.Context.Users.Add(usersItem1);

			var votesItem1 = new Votes();
			votesItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			this.Context.Votes.Add(votesItem1);

			var voteTypesItem1 = new VoteTypes();
			voteTypesItem1.SetProperties(1, "A");
			this.Context.VoteTypes.Add(voteTypesItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>294e2208e3296d6092add1880d9f5cc7</Hash>
</Codenesium>*/