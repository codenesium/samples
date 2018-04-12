using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class EmployeePayHistoryModelValidator: AbstractEmployeePayHistoryModelValidator, IEmployeePayHistoryModelValidator
	{
		public EmployeePayHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.RateChangeDateRules();
			this.RateRules();
			this.PayFrequencyRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.RateChangeDateRules();
			this.RateRules();
			this.PayFrequencyRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>cbc159d723da0217c73c5b6a2b9293cf</Hash>
</Codenesium>*/