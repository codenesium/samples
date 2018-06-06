using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiLessonStatusRequestModelValidator: AbstractApiLessonStatusRequestModelValidator, IApiLessonStatusRequestModelValidator
	{
		public ApiLessonStatusRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>f01e077e89a424200a3ec5d763d17c05</Hash>
</Codenesium>*/