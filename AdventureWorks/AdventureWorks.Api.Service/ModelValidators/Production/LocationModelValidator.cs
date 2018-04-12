using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class LocationModelValidator: AbstractLocationModelValidator, ILocationModelValidator
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
    <Hash>94ba492c9a67acc95b5104c202f033c8</Hash>
</Codenesium>*/