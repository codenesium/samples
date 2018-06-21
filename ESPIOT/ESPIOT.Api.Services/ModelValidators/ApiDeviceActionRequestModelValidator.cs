using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
        public class ApiDeviceActionRequestModelValidator : AbstractApiDeviceActionRequestModelValidator, IApiDeviceActionRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>5dbaaba399e073367e50e0042a7f7e95</Hash>
</Codenesium>*/