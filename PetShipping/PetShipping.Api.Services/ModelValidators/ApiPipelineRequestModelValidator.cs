using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineRequestModelValidator : AbstractApiPipelineRequestModelValidator, IApiPipelineRequestModelValidator
	{
		public ApiPipelineRequestModelValidator(IPipelineRepository pipelineRepository)
			: base(pipelineRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>dae7934aa837092dd9065c7c0b59f384</Hash>
</Codenesium>*/