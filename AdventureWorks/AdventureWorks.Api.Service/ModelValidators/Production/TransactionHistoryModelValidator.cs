using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class TransactionHistoryModelValidator: AbstractTransactionHistoryModelValidator,ITransactionHistoryModelValidator
	{
		public TransactionHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductIDRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			this.QuantityRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductIDRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			this.QuantityRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.ProductIDRules();
			this.ReferenceOrderIDRules();
			this.ReferenceOrderLineIDRules();
			this.TransactionDateRules();
			this.TransactionTypeRules();
			this.QuantityRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>d6a4aae2cdf78974551a490abfed81e8</Hash>
</Codenesium>*/