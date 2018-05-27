using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiLessonXTeacherRequestModelValidator: AbstractApiLessonXTeacherRequestModelValidator, IApiLessonXTeacherRequestModelValidator
	{
		public ApiLessonXTeacherRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a5f6bda74517690b0fe499119fb84a59</Hash>
</Codenesium>*/