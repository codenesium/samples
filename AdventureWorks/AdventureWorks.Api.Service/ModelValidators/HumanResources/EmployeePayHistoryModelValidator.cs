using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class EmployeePayHistoryModelValidator: AbstractEmployeePayHistoryModelValidator,IEmployeePayHistoryModelValidator
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

		public void PatchMode()
		{
			this.RateChangeDateRules();
			this.RateRules();
			this.PayFrequencyRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>5c9fa4bde1dab08dec808290da04590a</Hash>
</Codenesium>*/