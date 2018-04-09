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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e569f0f2328d600114c3c3703d4838d2</Hash>
</Codenesium>*/