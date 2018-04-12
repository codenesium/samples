using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class TransactionHistoryArchiveModelValidator: AbstractTransactionHistoryArchiveModelValidator, ITransactionHistoryArchiveModelValidator
	{
		public TransactionHistoryArchiveModelValidator()
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
    <Hash>2a16d4eb00dd3b02a62d81c905b392b8</Hash>
</Codenesium>*/