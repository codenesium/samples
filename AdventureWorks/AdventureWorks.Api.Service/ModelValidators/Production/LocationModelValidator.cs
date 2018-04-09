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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>aad59b56c8498ad99e09b21569ea512c</Hash>
</Codenesium>*/