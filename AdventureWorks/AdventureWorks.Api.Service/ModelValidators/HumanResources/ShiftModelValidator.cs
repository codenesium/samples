using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ShiftModelValidator: AbstractShiftModelValidator,IShiftModelValidator
	{
		public ShiftModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.StartTimeRules();
			this.EndTimeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.StartTimeRules();
			this.EndTimeRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>23e6f4319ce8f0221843db75c18ac005</Hash>
</Codenesium>*/