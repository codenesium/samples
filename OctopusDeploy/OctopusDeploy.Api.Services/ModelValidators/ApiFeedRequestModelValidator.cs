using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiFeedRequestModelValidator: AbstractApiFeedRequestModelValidator, IApiFeedRequestModelValidator
        {
                public ApiFeedRequestModelValidator(IFeedRepository feedRepository)
                        : base(feedRepository)
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
    <Hash>20149fa36e5ff542397be7951e206900</Hash>
</Codenesium>*/