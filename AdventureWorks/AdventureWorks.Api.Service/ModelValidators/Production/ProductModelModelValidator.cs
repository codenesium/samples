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

		public void PatchMode()
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b619bd341656669b3478cd543f317e97</Hash>
</Codenesium>*/