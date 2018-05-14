using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineStepModelValidator: AbstractApiPipelineStepModelValidator, IApiPipelineStepModelValidator
	{
		public ApiPipelineStepModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4c7dcd2e379947d3e110c97df6c9dc2b</Hash>
</Codenesium>*/