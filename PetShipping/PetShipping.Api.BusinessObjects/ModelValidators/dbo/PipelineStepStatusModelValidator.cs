using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineStepStatusModelValidator: AbstractPipelineStepStatusModelValidator, IPipelineStepStatusModelValidator
	{
		public PipelineStepStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineStepStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepStatusModel model)
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
    <Hash>dc19a6eb7fdb80da161e48fb1173a0ab</Hash>
</Codenesium>*/