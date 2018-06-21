using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiInvitationRequestModelValidator : AbstractApiInvitationRequestModelValidator, IApiInvitationRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>a9c6977e83fd85d5d9cb0b33c96fc57f</Hash>
</Codenesium>*/