using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileServiceNS.Api.DataAccess
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
			var bucketItem1 = new Bucket();
			bucketItem1.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A");
			this.context.Buckets.Add(bucketItem1);

			var fileItem1 = new File();
			fileItem1.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, 1, "A", "A", "A");
			this.context.Files.Add(fileItem1);

			var fileTypeItem1 = new FileType();
			fileTypeItem1.SetProperties(1, "A");
			this.context.FileTypes.Add(fileTypeItem1);

			var versionInfoItem1 = new VersionInfo();
			versionInfoItem1.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.context.VersionInfoes.Add(versionInfoItem1);

			this.context.SaveChanges();
		}
	}
}

/*<Codenesium>
    <Hash>164918e470fbeb97bb005dda924b35ac</Hash>
</Codenesium>*/