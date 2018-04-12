using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductPhotoModelValidator: AbstractProductPhotoModelValidator, IProductPhotoModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>ca7bb7108053dd6b9e4c30129b00eb5a</Hash>
</Codenesium>*/