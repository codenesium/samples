using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiOtherTransportServerRequestModelValidator : AbstractApiOtherTransportServerRequestModelValidator, IApiOtherTransportServerRequestModelValidator
	{
		public ApiOtherTransportServerRequestModelValidator(IOtherTransportRepository otherTransportRepository)
			: base(otherTransportRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportServerRequestModel model)
		{
			this.HandlerIdRules();
			this.PipelineStepIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportServerRequestModel model)
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
    <Hash>8e716388481e7f4d8d192eeaeefb2390</Hash>
</Codenesium>*/