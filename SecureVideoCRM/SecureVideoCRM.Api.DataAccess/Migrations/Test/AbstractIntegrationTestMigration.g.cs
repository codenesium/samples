using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.DataAccess
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
			var videoItem1 = new Video();
			videoItem1.SetProperties(1, "A", "A", "A");
			this.Context.Videos.Add(videoItem1);

			var userItem1 = new User();
			userItem1.SetProperties(1, "A", "A", 1);
			this.Context.Users.Add(userItem1);

			var subscriptionItem1 = new Subscription();
			subscriptionItem1.SetProperties(1, "A");
			this.Context.Subscriptions.Add(subscriptionItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>e9b05fe8618fd009f377f16fc8c00a81</Hash>
</Codenesium>*/