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

		public void PatchMode()
		{
			this.NameRules();
			this.SalesPersonIDRules();
			this.DemographicsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>9753f2170ae67a367a0a3f710187897d</Hash>
</Codenesium>*/