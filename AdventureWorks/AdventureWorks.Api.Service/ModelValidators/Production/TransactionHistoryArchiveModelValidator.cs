using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class TransactionHistoryArchiveModelValidator: AbstractTransactionHistoryArchiveModelValidator,ITransactionHistoryArchiveModelValidator
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
    <Hash>50aabd154860112dbf36277960697048</Hash>
</Codenesium>*/