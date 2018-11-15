using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepServerRequestModelValidator : AbstractApiPipelineStepServerRequestModelValidator, IApiPipelineStepServerRequestModelValidator
	{
		public ApiPipelineStepServerRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
			: base(pipelineStepRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepServerRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepServerRequestModel model)
		{
			this.NameRules();
			this.PipelineStepStatusIdRules();
			this.ShipperIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>097c8b258813aa313fa895538ce63484</Hash>
</Codenesium>*/