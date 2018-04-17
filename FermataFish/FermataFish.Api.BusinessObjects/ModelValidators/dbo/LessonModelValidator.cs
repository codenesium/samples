using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class LessonModelValidator: AbstractLessonModelValidator, ILessonModelValidator
	{
		public LessonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(LessonModel model)
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, LessonModel model)
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>50199998146c44db55054a2a3714128a</Hash>
</Codenesium>*/