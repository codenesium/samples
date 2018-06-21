using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public class ApiMachineRequestModelValidator : AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
        {
                public ApiMachineRequestModelValidator(IMachineRepository machineRepository)
                        : base(machineRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model)
                {
                        this.DescriptionRules();
                        this.JwtKeyRules();
                        this.LastIpAddressRules();
                        this.MachineGuidRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model)
                {
                        this.DescriptionRules();
                        this.JwtKeyRules();
                        this.LastIpAddressRules();
                        this.MachineGuidRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>82fe3cbe63520b07f3ec9aeb388eb61b</Hash>
</Codenesium>*/