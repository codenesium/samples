using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonXStudentRequestModelValidator: AbstractApiLessonXStudentRequestModelValidator, IApiLessonXStudentRequestModelValidator
	{
		public ApiLessonXStudentRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b001927e302fbc1b15e1d93fbdae5982</Hash>
</Codenesium>*/