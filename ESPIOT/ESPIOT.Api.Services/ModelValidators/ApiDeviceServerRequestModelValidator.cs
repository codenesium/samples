using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceServerRequestModelValidator : AbstractApiDeviceServerRequestModelValidator, IApiDeviceServerRequestModelValidator
	{
		public ApiDeviceServerRequestModelValidator(IDeviceRepository deviceRepository)
			: base(deviceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceServerRequestModel model)
		{
			this.DateOfLastPingRules();
			this.IsActiveRules();
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model)
		{
			this.DateOfLastPingRules();
			this.IsActiveRules();
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>c6586bb67132b83ef078221b224f1b33</Hash>
</Codenesium>*/