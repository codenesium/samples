using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiAccountRequestModelValidator: AbstractApiAccountRequestModelValidator, IApiAccountRequestModelValidator
        {
                public ApiAccountRequestModelValidator(IAccountRepository accountRepository)
                        : base(accountRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAccountRequestModel model)
                {
                        this.AccountTypeRules();
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiAccountRequestModel model)
                {
                        this.AccountTypeRules();
                        this.EnvironmentIdsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>20617b6b22227ce18d3a83002bc51ca5</Hash>
</Codenesium>*/