using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepRequestModelValidator: AbstractApiPipelineStepRequestModelValidator, IApiPipelineStepRequestModelValidator
	{
		public ApiPipelineStepRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b43364c8cec78c349cd5259d0ddc1766</Hash>
</Codenesium>*/