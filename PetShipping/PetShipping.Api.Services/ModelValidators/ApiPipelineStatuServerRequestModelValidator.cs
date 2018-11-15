using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatuServerRequestModelValidator : AbstractApiPipelineStatuServerRequestModelValidator, IApiPipelineStatuServerRequestModelValidator
	{
		public ApiPipelineStatuServerRequestModelValidator(IPipelineStatuRepository pipelineStatuRepository)
			: base(pipelineStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatuServerRequestModel model)
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
    <Hash>676d6afe48f012e1b5e424ac04216ec8</Hash>
</Codenesium>*/