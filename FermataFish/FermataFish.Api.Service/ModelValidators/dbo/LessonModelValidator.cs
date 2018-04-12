using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	public class LessonModelValidator: AbstractLessonModelValidator, ILessonModelValidator
	{
		public LessonModelValidator()
		{   }

		public void CreateMode()
		{
			this.ScheduledStartDateRules();
			this.ScheduledEndDateRules();
			this.ActualStartDateRules();
			this.ActualEndDateRules();
			this.LessonStatusIdRules();
			this.TeacherNotesRules();
			this.StudentNotesRules();
			this.BillAmountRules();
			this.StudioIdRules();
		}

		public void UpdateMode()
		{
			this.ScheduledStartDateRules();
			this.ScheduledEndDateRules();
			this.ActualStartDateRules();
			this.ActualEndDateRules();
			this.LessonStatusIdRules();
			this.TeacherNotesRules();
			this.StudentNotesRules();
			this.BillAmountRules();
			this.StudioIdRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>8a111366b81debf07cfe93fa5ed27a87</Hash>
</Codenesium>*/