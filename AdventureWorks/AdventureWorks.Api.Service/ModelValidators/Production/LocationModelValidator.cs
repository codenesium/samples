using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class LocationModelValidator: AbstractLocationModelValidator,ILocationModelValidator
	{
		public LocationModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.CostRateRules();
			this.AvailabilityRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.CostRateRules();
			this.AvailabilityRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.CostRateRules();
			this.AvailabilityRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>ba0945c320f19e25c6e66a33192f610b</Hash>
</Codenesium>*/