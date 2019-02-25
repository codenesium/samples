using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStepStatusServerRequestModelValidator : AbstractApiPipelineStepStatusServerRequestModelValidator, IApiPipelineStepStatusServerRequestModelValidator
	{
		public ApiPipelineStepStatusServerRequestModelValidator(IPipelineStepStatusRepository pipelineStepStatusRepository)
			: base(pipelineStepStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusServerRequestModel model)
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
    <Hash>240373968541263472c60d41dd50ab78</Hash>
</Codenesium>*/