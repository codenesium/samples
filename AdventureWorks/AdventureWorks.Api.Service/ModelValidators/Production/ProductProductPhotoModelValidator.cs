using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductProductPhotoModelValidator: AbstractProductProductPhotoModelValidator, IProductProductPhotoModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>b05cc8e1b4f540075528809d33540f93</Hash>
</Codenesium>*/