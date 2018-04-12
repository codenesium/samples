using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class LessonXStudentModelValidator: AbstractLessonXStudentModelValidator, ILessonXStudentModelValidator
	{
		public LessonXStudentModelValidator()
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
    <Hash>8906ee96db1a40b30d0efbd359db52f1</Hash>
</Codenesium>*/