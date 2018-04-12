using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class LessonXTeacherModelValidator: AbstractLessonXTeacherModelValidator, ILessonXTeacherModelValidator
	{
		public LessonXTeacherModelValidator()
		{   }

		public void CreateMode()
		{
			this.LessonIdRules();
			this.StudentIdRules();
		}

		public void UpdateMode()
		{
			this.LessonIdRules();
			this.StudentIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>0fb0403c85a6585eb0ca50e60924ad10</Hash>
</Codenesium>*/