using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiLessonRequestModelValidator: AbstractApiLessonRequestModelValidator, IApiLessonRequestModelValidator
	{
		public ApiLessonRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonRequestModel model)
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
    <Hash>e8a9d33551b3ed5f899e2346f5481da3</Hash>
</Codenesium>*/