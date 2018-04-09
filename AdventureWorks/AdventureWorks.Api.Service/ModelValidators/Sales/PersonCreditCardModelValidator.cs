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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1c791b689e87f5ee566a567913a15509</Hash>
</Codenesium>*/