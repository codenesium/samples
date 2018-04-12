using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class StoreModelValidator: AbstractStoreModelValidator, IStoreModelValidator
	{
		public StoreModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.SalesPersonIDRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.SalesPersonIDRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7b46950442aed6db3a3d32a31cdc99c9</Hash>
</Codenesium>*/