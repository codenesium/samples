using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
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
			var badgeItem1 = new Badge();
			badgeItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);
			this.context.Badges.Add(badgeItem1);

			var commentItem1 = new Comment();
			commentItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);
			this.context.Comments.Add(commentItem1);

			var linkTypeItem1 = new LinkType();
			linkTypeItem1.SetProperties(1, "A");
			this.context.LinkTypes.Add(linkTypeItem1);

			var postHistoryItem1 = new PostHistory();
			postHistoryItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", "A", "A", 1);
			this.context.PostHistories.Add(postHistoryItem1);

			var postHistoryTypeItem1 = new PostHistoryType();
			postHistoryTypeItem1.SetProperties(1, "A");
			this.context.PostHistoryTypes.Add(postHistoryTypeItem1);

			var postLinkItem1 = new PostLink();
			postLinkItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.context.PostLinks.Add(postLinkItem1);

			var postItem1 = new Post();
			postItem1.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			this.context.Posts.Add(postItem1);

			var postTypeItem1 = new PostType();
			postTypeItem1.SetProperties(1, "A");
			this.context.PostTypes.Add(postTypeItem1);

			var tagItem1 = new Tag();
			tagItem1.SetProperties(1, 1, 1, "A", 1);
			this.context.Tags.Add(tagItem1);

			var userItem1 = new User();
			userItem1.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			this.context.Users.Add(userItem1);

			var voteItem1 = new Vote();
			voteItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.context.Votes.Add(voteItem1);

			var voteTypeItem1 = new VoteType();
			voteTypeItem1.SetProperties(1, "A");
			this.context.VoteTypes.Add(voteTypeItem1);

			await this.context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>b493d335382eb2322af3edb352fb6c12</Hash>
</Codenesium>*/