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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>5d36eca4ceff1869c6bc249efffbe9cd</Hash>
</Codenesium>*/