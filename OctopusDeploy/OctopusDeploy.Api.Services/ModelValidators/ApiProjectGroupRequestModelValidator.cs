using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProjectGroupRequestModelValidator : AbstractApiProjectGroupRequestModelValidator, IApiProjectGroupRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>285bab51ff9c2cb76c81b3aded9688f3</Hash>
</Codenesium>*/