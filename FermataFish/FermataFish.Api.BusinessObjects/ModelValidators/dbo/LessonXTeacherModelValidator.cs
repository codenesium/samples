using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiLessonXTeacherModelValidator: AbstractApiLessonXTeacherModelValidator, IApiLessonXTeacherModelValidator
	{
		public ApiLessonXTeacherModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherModel model)
		{
			this.LessonIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherModel model)
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
    <Hash>cb53ab8aa9e2231bd641c1abf431355e</Hash>
</Codenesium>*/