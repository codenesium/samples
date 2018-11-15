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

		public virtual async void Migrate()
		{
			var badgeItem1 = new Badge();
			badgeItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);
			this.Context.Badges.Add(badgeItem1);

			var commentItem1 = new Comment();
			commentItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);
			this.Context.Comments.Add(commentItem1);

			var linkTypeItem1 = new LinkType();
			linkTypeItem1.SetProperties(1, "A");
			this.Context.LinkTypes.Add(linkTypeItem1);

			var postHistoryItem1 = new PostHistory();
			postHistoryItem1.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", "A", "A", 1);
			this.Context.PostHistories.Add(postHistoryItem1);

			var postHistoryTypeItem1 = new PostHistoryType();
			postHistoryTypeItem1.SetProperties(1, "A");
			this.Context.PostHistoryTypes.Add(postHistoryTypeItem1);

			var postLinkItem1 = new PostLink();
			postLinkItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.Context.PostLinks.Add(postLinkItem1);

			var postItem1 = new Post();
			postItem1.SetProperties(1, 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, 1, 1, "A", "A", 1);
			this.Context.Posts.Add(postItem1);

			var postTypeItem1 = new PostType();
			postTypeItem1.SetProperties(1, "A");
			this.Context.PostTypes.Add(postTypeItem1);

			var tagItem1 = new Tag();
			tagItem1.SetProperties(1, 1, 1, "A", 1);
			this.Context.Tags.Add(tagItem1);

			var userItem1 = new User();
			userItem1.SetProperties("A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, 1, 1, "A");
			this.Context.Users.Add(userItem1);

			var voteItem1 = new Vote();
			voteItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);
			this.Context.Votes.Add(voteItem1);

			var voteTypeItem1 = new VoteType();
			voteTypeItem1.SetProperties(1, "A");
			this.Context.VoteTypes.Add(voteTypeItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>35b4559ef889e00d200b9983159d8698</Hash>
</Codenesium>*/