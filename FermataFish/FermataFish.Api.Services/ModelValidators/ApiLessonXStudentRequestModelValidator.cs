using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonXStudentRequestModelValidator : AbstractApiLessonXStudentRequestModelValidator, IApiLessonXStudentRequestModelValidator
	{
		public ApiLessonXStudentRequestModelValidator(ILessonXStudentRepository lessonXStudentRepository)
			: base(lessonXStudentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>49bc738c8088344d9eec8e33561f7fbb</Hash>
</Codenesium>*/