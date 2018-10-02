using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatuRequestModelValidator : AbstractApiPipelineStatuRequestModelValidator, IApiPipelineStatuRequestModelValidator
	{
		public ApiPipelineStatuRequestModelValidator(IPipelineStatuRepository pipelineStatuRepository)
			: base(pipelineStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatuRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatuRequestModel model)
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
    <Hash>91be96a58b5d7878c9223657f976ddbe</Hash>
</Codenesium>*/