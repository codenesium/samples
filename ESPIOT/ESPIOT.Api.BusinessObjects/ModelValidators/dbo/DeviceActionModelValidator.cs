using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.BusinessObjects
{
	public class ApiDeviceActionRequestModelValidator: AbstractApiDeviceActionRequestModelValidator, IApiDeviceActionRequestModelValidator
	{
		public ApiDeviceActionRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceActionRequestModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceActionRequestModel model)
		{
			this.DeviceIdRules();
			this.NameRules();
			this.@ValueRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b461aa8dedfc0f26506022c289b8c16a</Hash>
</Codenesium>*/