using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
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
			var bucketItem1 = new Bucket();
			bucketItem1.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");
			this.Context.Buckets.Add(bucketItem1);

			var fileItem1 = new File();
			fileItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1, "A", "A", "A");
			this.Context.Files.Add(fileItem1);

			var fileTypeItem1 = new FileType();
			fileTypeItem1.SetProperties(1, "A");
			this.Context.FileTypes.Add(fileTypeItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>78d55db52f281987a7d2bec1f84f62df</Hash>
</Codenesium>*/