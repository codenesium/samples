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

		public void PatchMode()
		{
			this.ProductDescriptionIDRules();
			this.CultureIDRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>17c94de723a5e15fd998e949fd18180e</Hash>
</Codenesium>*/