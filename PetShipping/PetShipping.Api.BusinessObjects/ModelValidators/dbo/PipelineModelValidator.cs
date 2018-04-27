using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineModelValidator: AbstractPipelineModelValidator, IPipelineModelValidator
	{
		public PipelineModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineModel model)
		{
			this.PipelineStatusIdRules();
			this.SaleIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineModel model)
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
    <Hash>6945bceecff7ab0366b153d7f27f3c4c</Hash>
</Codenesium>*/