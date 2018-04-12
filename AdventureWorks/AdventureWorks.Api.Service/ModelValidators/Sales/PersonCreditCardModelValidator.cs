using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PersonCreditCardModelValidator: AbstractPersonCreditCardModelValidator, IPersonCreditCardModelValidator
	{
		public PersonCreditCardModelValidator()
		{   }

		public void CreateMode()
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>21a5ed3f4f9711599c285ff278859d07</Hash>
</Codenesium>*/