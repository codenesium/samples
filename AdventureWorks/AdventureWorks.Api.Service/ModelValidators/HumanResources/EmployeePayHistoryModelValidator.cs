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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>53c3ae21fdb50308b4abad93f8ddf88d</Hash>
</Codenesium>*/