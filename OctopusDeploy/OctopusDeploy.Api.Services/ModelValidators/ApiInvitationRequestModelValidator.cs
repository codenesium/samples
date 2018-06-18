using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiInvitationRequestModelValidator: AbstractApiInvitationRequestModelValidator, IApiInvitationRequestModelValidator
        {
                public ApiInvitationRequestModelValidator(IInvitationRepository invitationRepository)
                        : base(invitationRepository)
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
    <Hash>424c4f046cdb2a4d6318a75845efe9c2</Hash>
</Codenesium>*/