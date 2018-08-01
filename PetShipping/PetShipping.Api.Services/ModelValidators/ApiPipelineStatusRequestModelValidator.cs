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
    <Hash>1e57b5d70b07f2dc867196f49a7b49a9</Hash>
</Codenesium>*/