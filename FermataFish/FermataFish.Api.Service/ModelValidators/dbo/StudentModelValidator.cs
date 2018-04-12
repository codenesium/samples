using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class StudentModelValidator: AbstractStudentModelValidator, IStudentModelValidator
	{
		public StudentModelValidator()
		{   }

		public void CreateMode()
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.IsAdultRules();
			this.BirthdayRules();
			this.FamilyIdRules();
			this.StudioIdRules();
			this.SmsRemindersEnabledRules();
			this.EmailRemindersEnabledRules();
		}

		public void UpdateMode()
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.IsAdultRules();
			this.BirthdayRules();
			this.FamilyIdRules();
			this.StudioIdRules();
			this.SmsRemindersEnabledRules();
			this.EmailRemindersEnabledRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>c5506405ab62cb733bd47f689afa8646</Hash>
</Codenesium>*/