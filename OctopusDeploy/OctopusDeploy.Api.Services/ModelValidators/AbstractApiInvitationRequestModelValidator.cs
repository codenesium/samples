using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiInvitationRequestModelValidator : AbstractValidator<ApiInvitationRequestModel>
        {
                private string existingRecordId;

                private IInvitationRepository invitationRepository;

                public AbstractApiInvitationRequestModelValidator(IInvitationRepository invitationRepository)
                {
                        this.invitationRepository = invitationRepository;
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
    <Hash>59e83e79143960f3377a078cb8831314</Hash>
</Codenesium>*/