using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductModelProductDescriptionCultureModelValidator: AbstractProductModelProductDescriptionCultureModelValidator, IProductModelProductDescriptionCultureModelValidator
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
    <Hash>9f47124500d447f724ebe34ff07bbaba</Hash>
</Codenesium>*/