using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class SpaceModelValidator: AbstractSpaceModelValidator, ISpaceModelValidator
	{
		public SpaceModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.DescriptionRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.DescriptionRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>02432d18b23edd66d6e43058dc9558e1</Hash>
</Codenesium>*/