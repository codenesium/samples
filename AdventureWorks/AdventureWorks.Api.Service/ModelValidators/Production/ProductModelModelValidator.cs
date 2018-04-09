using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductModelModelValidator: AbstractProductModelModelValidator,IProductModelModelValidator
	{
		public ProductModelModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7c80d6119a1c4b8446bc7705bf4f8583</Hash>
</Codenesium>*/