using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class StudioModelValidator: AbstractStudioModelValidator, IStudioModelValidator
	{
		public StudioModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.WebsiteRules();
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateIdRules();
			this.ZipRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.WebsiteRules();
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateIdRules();
			this.ZipRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>65d184d9815d958212292de4e2e6150d</Hash>
</Codenesium>*/