using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class OtherTransportModelValidator: AbstractOtherTransportModelValidator, IOtherTransportModelValidator
	{
		public OtherTransportModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(OtherTransportModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, OtherTransportModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>53e8798b8f3eddafa072cbf77de79d08</Hash>
</Codenesium>*/