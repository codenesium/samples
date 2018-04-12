using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class TeacherXTeacherSkillModelValidator: AbstractTeacherXTeacherSkillModelValidator, ITeacherXTeacherSkillModelValidator
	{
		public TeacherXTeacherSkillModelValidator()
		{   }

		public void CreateMode()
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
		}

		public void UpdateMode()
		{
			this.TeacherIdRules();
			this.TeacherSkillIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e46f4d10d90dbd0d74da6aa0bbd36ba4</Hash>
</Codenesium>*/