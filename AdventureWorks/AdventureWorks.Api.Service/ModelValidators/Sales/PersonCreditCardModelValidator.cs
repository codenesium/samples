using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PersonCreditCardModelValidator: AbstractPersonCreditCardModelValidator,IPersonCreditCardModelValidator
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

		public void PatchMode()
		{
			this.CreditCardIDRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>af26e3822888a7a03a83326ab4df8d77</Hash>
</Codenesium>*/