using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductModelProductDescriptionCultureModelValidator: AbstractProductModelProductDescriptionCultureModelValidator,IProductModelProductDescriptionCultureModelValidator
	{
		public ProductModelProductDescriptionCultureModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductDescriptionIDRules();
			this.CultureIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductDescriptionIDRules();
			this.CultureIDRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>91afeb1342f73169b6b68b7c780fbe38</Hash>
</Codenesium>*/