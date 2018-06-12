using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiInvitationRequestModelValidator: AbstractApiInvitationRequestModelValidator, IApiInvitationRequestModelValidator
        {
                public ApiInvitationRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiInvitationRequestModel model)
                {
                        this.InvitationCodeRules();
                        this.JSONRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiInvitationRequestModel model)
                {
                        this.InvitationCodeRules();
                        this.JSONRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>8c7f22bedefa8d5f78ff243fac321c4e</Hash>
</Codenesium>*/