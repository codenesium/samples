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

		public void PatchMode()
		{
			this.PhoneNumberRules();
			this.PhoneNumberTypeIDRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>1cd09cdca07386fdf1bb821817655c4e</Hash>
</Codenesium>*/