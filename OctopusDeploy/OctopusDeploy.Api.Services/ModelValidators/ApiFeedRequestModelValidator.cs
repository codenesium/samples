using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiFeedRequestModelValidator: AbstractApiFeedRequestModelValidator, IApiFeedRequestModelValidator
        {
                public ApiFeedRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model)
                {
                        this.FeedTypeRules();
                        this.FeedUriRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model)
                {
                        this.FeedTypeRules();
                        this.FeedUriRules();
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
    <Hash>874f6057693d8af912fd2afea4ba8a94</Hash>
</Codenesium>*/