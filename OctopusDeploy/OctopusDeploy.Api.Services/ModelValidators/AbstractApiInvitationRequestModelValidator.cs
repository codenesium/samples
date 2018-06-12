using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiInvitationRequestModelValidator: AbstractValidator<ApiInvitationRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiInvitationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiInvitationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void InvitationCodeRules()
                {
                        this.RuleFor(x => x.InvitationCode).NotNull();
                        this.RuleFor(x => x.InvitationCode).Length(0, 200);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>362fd1f7b6a25cd3d82e0fedaf20238a</Hash>
</Codenesium>*/