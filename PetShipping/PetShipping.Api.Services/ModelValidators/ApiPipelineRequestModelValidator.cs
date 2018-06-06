using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineRequestModelValidator: AbstractApiPipelineRequestModelValidator, IApiPipelineRequestModelValidator
	{
		public ApiPipelineRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>5908eaeffc101477b48194ba5c4ef0d6</Hash>
</Codenesium>*/