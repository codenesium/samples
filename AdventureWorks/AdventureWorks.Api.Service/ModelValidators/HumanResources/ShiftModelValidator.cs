using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ShiftModelValidator: AbstractShiftModelValidator, IShiftModelValidator
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
    <Hash>06a3af9e954cfa7be0bc12a7c5d81f56</Hash>
</Codenesium>*/