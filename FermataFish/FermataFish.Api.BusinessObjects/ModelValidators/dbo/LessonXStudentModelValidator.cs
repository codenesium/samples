using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiLessonXStudentModelValidator: AbstractApiLessonXStudentModelValidator, IApiLessonXStudentModelValidator
	{
		public ApiLessonXStudentModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>13cb16f4b74cfd0c5541dd6d0caa5379</Hash>
</Codenesium>*/