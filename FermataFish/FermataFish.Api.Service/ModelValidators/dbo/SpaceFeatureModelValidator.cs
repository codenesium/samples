using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class SpaceFeatureModelValidator: AbstractSpaceFeatureModelValidator, ISpaceFeatureModelValidator
	{
		public SpaceFeatureModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>90608e7320c5c4085fe6380f5f4cce74</Hash>
</Codenesium>*/