using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PersonPhoneModelValidator: AbstractPersonPhoneModelValidator,IPersonPhoneModelValidator
	{
		public PersonPhoneModelValidator()
		{   }

		public void CreateMode()
		{
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>54ddcc725a8389f16ceb58957bdadb9d</Hash>
</Codenesium>*/