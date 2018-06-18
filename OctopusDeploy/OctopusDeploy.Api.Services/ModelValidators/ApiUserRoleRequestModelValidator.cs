using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiUserRoleRequestModelValidator: AbstractApiUserRoleRequestModelValidator, IApiUserRoleRequestModelValidator
        {
                public ApiUserRoleRequestModelValidator(IUserRoleRepository userRoleRepository)
                        : base(userRoleRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiUserRoleRequestModel model)
                {
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRoleRequestModel model)
                {
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a0d2656ff0514d6714d91a1423100ff7</Hash>
</Codenesium>*/