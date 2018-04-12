using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductDescriptionModelValidator: AbstractProductDescriptionModelValidator, IProductDescriptionModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>784a9ee7a08df78707ec819af289078d</Hash>
</Codenesium>*/