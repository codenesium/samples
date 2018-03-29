using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductDescriptionModelValidator: AbstractProductDescriptionModelValidator,IProductDescriptionModelValidator
	{
		public ProductDescriptionModelValidator()
		{   }

		public void CreateMode()
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>ce27c732323c9811b1fd7cd185250045</Hash>
</Codenesium>*/