using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class StudentXFamilyModelValidator: AbstractStudentXFamilyModelValidator, IStudentXFamilyModelValidator
	{
		public StudentXFamilyModelValidator()
		{   }

		public void CreateMode()
		{
			this.StudentIdRules();
			this.FamilyIdRules();
		}

		public void UpdateMode()
		{
			this.StudentIdRules();
			this.FamilyIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>331c4ff55109c327efa1cb5e7feac335</Hash>
</Codenesium>*/