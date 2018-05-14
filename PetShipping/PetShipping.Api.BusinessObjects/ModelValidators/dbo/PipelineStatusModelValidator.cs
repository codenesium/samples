using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineStatusModelValidator: AbstractApiPipelineStatusModelValidator, IApiPipelineStatusModelValidator
	{
		public ApiPipelineStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>14e57b5b196f2ab48fe4a3452e863308</Hash>
</Codenesium>*/