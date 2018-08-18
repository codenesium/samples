using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonXTeacherRequestModelValidator : AbstractApiLessonXTeacherRequestModelValidator, IApiLessonXTeacherRequestModelValidator
	{
		public ApiLessonXTeacherRequestModelValidator(ILessonXTeacherRepository lessonXTeacherRepository)
			: base(lessonXTeacherRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>af431385c078dbda630a73ac331ccab1</Hash>
</Codenesium>*/