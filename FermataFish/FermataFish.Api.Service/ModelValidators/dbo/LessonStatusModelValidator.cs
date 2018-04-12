using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class LessonStatusModelValidator: AbstractLessonStatusModelValidator, ILessonStatusModelValidator
	{
		public LessonStatusModelValidator()
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
    <Hash>879c7d940b7fd887dab88a52d8653e82</Hash>
</Codenesium>*/