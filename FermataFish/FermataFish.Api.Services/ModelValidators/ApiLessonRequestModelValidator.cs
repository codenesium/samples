using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonRequestModelValidator : AbstractApiLessonRequestModelValidator, IApiLessonRequestModelValidator
	{
		public ApiLessonRequestModelValidator(ILessonRepository lessonRepository)
			: base(lessonRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>028bad5493796a202fa124ab582c8c86</Hash>
</Codenesium>*/