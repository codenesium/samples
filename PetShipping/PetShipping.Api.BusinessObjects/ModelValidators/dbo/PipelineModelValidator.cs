using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPipelineModelValidator: AbstractApiPipelineModelValidator, IApiPipelineModelValidator
	{
		public ApiPipelineModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>bbfdd16d8844454c540990ea6e8a4d25</Hash>
</Codenesium>*/