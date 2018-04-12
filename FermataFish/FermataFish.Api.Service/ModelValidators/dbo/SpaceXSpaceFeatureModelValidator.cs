using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class SpaceXSpaceFeatureModelValidator: AbstractSpaceXSpaceFeatureModelValidator, ISpaceXSpaceFeatureModelValidator
	{
		public SpaceXSpaceFeatureModelValidator()
		{   }

		public void CreateMode()
		{
			this.SpaceIdRules();
			this.SpaceFeatureIdRules();
		}

		public void UpdateMode()
		{
			this.SpaceIdRules();
			this.SpaceFeatureIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1d86c20d298be585c4c8677e12a76b25</Hash>
</Codenesium>*/