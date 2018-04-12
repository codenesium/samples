using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class TransactionHistoryModelValidator: AbstractTransactionHistoryModelValidator, ITransactionHistoryModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>12056b10fedb6d3c7527f499e1e9fdf0</Hash>
</Codenesium>*/