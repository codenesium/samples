using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class PersonPhoneModelValidator: AbstractPersonPhoneModelValidator, IPersonPhoneModelValidator
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
    <Hash>5f57c7806568574ee3cedf29a56cc491</Hash>
</Codenesium>*/