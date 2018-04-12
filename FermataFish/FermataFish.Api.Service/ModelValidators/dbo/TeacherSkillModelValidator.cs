using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class TeacherSkillModelValidator: AbstractTeacherSkillModelValidator, ITeacherSkillModelValidator
	{
		public TeacherSkillModelValidator()
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
    <Hash>52c40e5411b265ed730f995a2d457bec</Hash>
</Codenesium>*/