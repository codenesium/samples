using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiOtherTransportRequestModelValidator : AbstractApiOtherTransportRequestModelValidator, IApiOtherTransportRequestModelValidator
	{
		public ApiOtherTransportRequestModelValidator(IOtherTransportRepository otherTransportRepository)
			: base(otherTransportRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>8f308006e79659d04b75ad876c79662e</Hash>
</Codenesium>*/