using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiMachineRequestModelValidator: AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>06cd792094508cb30f99fdf10dd65da9</Hash>
</Codenesium>*/