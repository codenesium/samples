using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class PhoneNumberTypeModelValidator: AbstractPhoneNumberTypeModelValidator,IPhoneNumberTypeModelValidator
	{
		public PhoneNumberTypeModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>11f48c1bf7c1a7141fc918ba2d553cc5</Hash>
</Codenesium>*/