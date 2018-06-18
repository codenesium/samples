using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiAdminRequestModelValidator: AbstractApiAdminRequestModelValidator, IApiAdminRequestModelValidator
        {
                public ApiAdminRequestModelValidator(IAdminRepository adminRepository)
                        : base(adminRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model)
                {
                        this.BirthdayRules();
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model)
                {
                        this.BirthdayRules();
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PhoneRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2af6a81ff7b7b466b747e4dd6b121d95</Hash>
</Codenesium>*/