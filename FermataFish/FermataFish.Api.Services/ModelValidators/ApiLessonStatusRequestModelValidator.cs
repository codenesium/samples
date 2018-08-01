using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonStatusRequestModelValidator : AbstractApiLessonStatusRequestModelValidator, IApiLessonStatusRequestModelValidator
	{
		public ApiLessonStatusRequestModelValidator(ILessonStatusRepository lessonStatusRepository)
			: base(lessonStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLessonStatusRequestModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonStatusRequestModel model)
		{
			this.NameRules();
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
    <Hash>f7d3e308154c528b486f518e230161de</Hash>
</Codenesium>*/