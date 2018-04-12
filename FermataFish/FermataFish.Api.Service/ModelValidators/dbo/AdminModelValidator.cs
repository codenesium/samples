using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class AdminModelValidator: AbstractAdminModelValidator, IAdminModelValidator
	{
		public AdminModelValidator()
		{   }

		public void CreateMode()
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>aede7e88bd078f562f9fbf47b2ec758a</Hash>
</Codenesium>*/