using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiUserRequestModelValidator: AbstractApiUserRequestModelValidator, IApiUserRequestModelValidator
        {
                public ApiUserRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model)
                {
                        this.DisplayNameRules();
                        this.EmailAddressRules();
                        this.ExternalIdRules();
                        this.ExternalIdentifiersRules();
                        this.IdentificationTokenRules();
                        this.IsActiveRules();
                        this.IsServiceRules();
                        this.JSONRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model)
                {
                        this.DisplayNameRules();
                        this.EmailAddressRules();
                        this.ExternalIdRules();
                        this.ExternalIdentifiersRules();
                        this.IdentificationTokenRules();
                        this.IsActiveRules();
                        this.IsServiceRules();
                        this.JSONRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a37d27c5efa65a591cc2e7012f0ad662</Hash>
</Codenesium>*/