using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineServerRequestModelValidator : AbstractApiPipelineServerRequestModelValidator, IApiPipelineServerRequestModelValidator
	{
		public ApiPipelineServerRequestModelValidator(IPipelineRepository pipelineRepository)
			: base(pipelineRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineServerRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineServerRequestModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a989eefc5ad37d0f0a276de4baf6dc9c</Hash>
</Codenesium>*/