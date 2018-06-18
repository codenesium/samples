using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProjectGroupRequestModelValidator: AbstractApiProjectGroupRequestModelValidator, IApiProjectGroupRequestModelValidator
        {
                public ApiProjectGroupRequestModelValidator(IProjectGroupRepository projectGroupRepository)
                        : base(projectGroupRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProjectGroupRequestModel model)
                {
                        this.DataVersionRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectGroupRequestModel model)
                {
                        this.DataVersionRules();
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
    <Hash>85ba46b236ede75380aca424c2972f80</Hash>
</Codenesium>*/