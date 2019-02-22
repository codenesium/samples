using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiUnitDispositionServerRequestModelValidator : AbstractApiUnitDispositionServerRequestModelValidator, IApiUnitDispositionServerRequestModelValidator
	{
		public ApiUnitDispositionServerRequestModelValidator(IUnitDispositionRepository unitDispositionRepository)
			: base(unitDispositionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitDispositionServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitDispositionServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9d89fde74ab6d3ef6f4efadac27c493a</Hash>
</Codenesium>*/