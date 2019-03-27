using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiOffCapabilityServerRequestModelValidator : AbstractApiOffCapabilityServerRequestModelValidator, IApiOffCapabilityServerRequestModelValidator
	{
		public ApiOffCapabilityServerRequestModelValidator(IOffCapabilityRepository offCapabilityRepository)
			: base(offCapabilityRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOffCapabilityServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOffCapabilityServerRequestModel model)
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
    <Hash>af81ea552a71a65ccabea448f3c0c440</Hash>
</Codenesium>*/