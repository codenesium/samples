using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiLessonModelValidator: AbstractApiLessonModelValidator, IApiLessonModelValidator
	{
		public ApiLessonModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.LessonStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNotesRules();
			this.StudioIdRules();
			this.TeacherNotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonModel model)
		{
			this.ActualEndDateRules();
			this.ActualStartDateRules();
			this.BillAmountRules();
			this.LessonStatusIdRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			this.StudentNotesRules();
			this.StudioIdRules();
			this.TeacherNotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9abbb681eeb164d3dac1419041869d1a</Hash>
</Codenesium>*/