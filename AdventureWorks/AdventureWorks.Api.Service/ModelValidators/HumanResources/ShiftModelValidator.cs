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

		public void PatchMode()
		{
			this.NameRules();
			this.StartTimeRules();
			this.EndTimeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b88aa968af01064b22ff6685e61d5c62</Hash>
</Codenesium>*/