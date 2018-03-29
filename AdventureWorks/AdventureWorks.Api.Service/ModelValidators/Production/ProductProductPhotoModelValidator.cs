using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductProductPhotoModelValidator: AbstractProductProductPhotoModelValidator,IProductProductPhotoModelValidator
	{
		public ProductProductPhotoModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductPhotoIDRules();
			this.PrimaryRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductPhotoIDRules();
			this.PrimaryRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.ProductPhotoIDRules();
			this.PrimaryRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>7101c147f4c9582bff7bbd8558623c70</Hash>
</Codenesium>*/