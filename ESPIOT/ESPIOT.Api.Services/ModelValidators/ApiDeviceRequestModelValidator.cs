using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public class ApiDeviceRequestModelValidator: AbstractApiDeviceRequestModelValidator, IApiDeviceRequestModelValidator
        {
                public ApiDeviceRequestModelValidator(IDeviceRepository deviceRepository)
                        : base(deviceRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDeviceRequestModel model)
                {
                        this.NameRules();
                        this.PublicIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDeviceRequestModel model)
                {
                        this.NameRules();
                        this.PublicIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>db07910a518836d6b953bdd8802a1937</Hash>
</Codenesium>*/