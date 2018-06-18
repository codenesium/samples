using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public class ApiDeviceActionRequestModelValidator: AbstractApiDeviceActionRequestModelValidator, IApiDeviceActionRequestModelValidator
        {
                public ApiDeviceActionRequestModelValidator(IDeviceActionRepository deviceActionRepository)
                        : base(deviceActionRepository)
                {
                }

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
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>1de1a9bd098f52c8712adcf770194ed6</Hash>
</Codenesium>*/