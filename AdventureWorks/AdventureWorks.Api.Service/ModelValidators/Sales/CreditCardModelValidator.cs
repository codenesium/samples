using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class CreditCardModelValidator: AbstractCreditCardModelValidator,ICreditCardModelValidator
	{
		public CreditCardModelValidator()
		{   }

		public void CreateMode()
		{
			this.CardTypeRules();
			this.CardNumberRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.CardTypeRules();
			this.CardNumberRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>6bf73743022d1296ff5d0a9d1efff7f0</Hash>
</Codenesium>*/