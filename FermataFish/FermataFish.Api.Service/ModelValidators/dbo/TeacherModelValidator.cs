using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class TeacherModelValidator: AbstractTeacherModelValidator, ITeacherModelValidator
	{
		public TeacherModelValidator()
		{   }

		public void CreateMode()
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.EmailRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.EmailRules();
			this.PhoneRules();
			this.BirthdayRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>60ff39c87d1d8ece260b02e5f41473c2</Hash>
</Codenesium>*/