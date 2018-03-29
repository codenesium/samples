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

		public void PatchMode()
		{
			this.CardTypeRules();
			this.CardNumberRules();
			this.ExpMonthRules();
			this.ExpYearRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>b4aee50b6746b5c647b229a8849d38c3</Hash>
</Codenesium>*/