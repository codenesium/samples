using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductPhotoModelValidator: AbstractProductPhotoModelValidator,IProductPhotoModelValidator
	{
		public ProductPhotoModelValidator()
		{   }

		public void CreateMode()
		{
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>e49224b597d15a3e7dfa881020f08fa1</Hash>
</Codenesium>*/