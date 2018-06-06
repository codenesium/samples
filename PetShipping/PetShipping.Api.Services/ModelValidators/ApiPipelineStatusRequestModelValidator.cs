using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatusRequestModelValidator: AbstractApiPipelineStatusRequestModelValidator, IApiPipelineStatusRequestModelValidator
	{
		public ApiPipelineStatusRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d86784f23c7a7901f6a16d90e4294b25</Hash>
</Codenesium>*/