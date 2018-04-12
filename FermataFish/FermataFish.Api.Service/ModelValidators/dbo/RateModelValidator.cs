using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class RateModelValidator: AbstractRateModelValidator, IRateModelValidator
	{
		public RateModelValidator()
		{   }

		public void CreateMode()
		{
			this.AmountPerMinuteRules();
			this.TeacherSkillIdRules();
			this.TeacherIdRules();
		}

		public void UpdateMode()
		{
			this.AmountPerMinuteRules();
			this.TeacherSkillIdRules();
			this.TeacherIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>282dc0f845c4835895b314e362eca392</Hash>
</Codenesium>*/