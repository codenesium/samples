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
			this.NameRules();
			this.PublicIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceServerRequestModel model)
		{
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
    <Hash>05e767a71fe6c96f11cafcf9751412f5</Hash>
</Codenesium>*/