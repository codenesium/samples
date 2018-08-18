using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatusRequestModelValidator : AbstractApiPipelineStatusRequestModelValidator, IApiPipelineStatusRequestModelValidator
	{
		public ApiPipelineStatusRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
			: base(pipelineStatusRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ec7600571249e6e41119bc64f308c0f1</Hash>
</Codenesium>*/