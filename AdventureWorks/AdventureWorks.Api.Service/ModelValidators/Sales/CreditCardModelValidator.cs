using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class CreditCardModelValidator: AbstractCreditCardModelValidator, ICreditCardModelValidator
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
    <Hash>2f20e4a12d7560489a404e40cbcc7085</Hash>
</Codenesium>*/