using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPipelineStatusServerRequestModelValidator : AbstractApiPipelineStatusServerRequestModelValidator, IApiPipelineStatusServerRequestModelValidator
	{
		public ApiPipelineStatusServerRequestModelValidator(IPipelineStatusRepository pipelineStatusRepository)
			: base(pipelineStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusServerRequestModel model)
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
    <Hash>ae5b631286bd5107c872bf0f132f28e8</Hash>
</Codenesium>*/