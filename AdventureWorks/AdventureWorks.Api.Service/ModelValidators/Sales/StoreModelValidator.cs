using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class StoreModelValidator: AbstractStoreModelValidator,IStoreModelValidator
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
    <Hash>10d62bfba4732ca9f680bbd790680b6b</Hash>
</Codenesium>*/