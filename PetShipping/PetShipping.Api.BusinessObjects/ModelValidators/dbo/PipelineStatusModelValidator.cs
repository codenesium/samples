using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PipelineStatusModelValidator: AbstractPipelineStatusModelValidator, IPipelineStatusModelValidator
	{
		public PipelineStatusModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PipelineStatusModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStatusModel model)
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
    <Hash>2bc0156ad1c472c7cef14d2e82329ea5</Hash>
</Codenesium>*/