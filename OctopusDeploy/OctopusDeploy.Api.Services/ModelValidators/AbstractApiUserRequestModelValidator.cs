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
        public abstract class AbstractApiUserRequestModelValidator: AbstractValidator<ApiUserRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiUserRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiUserRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IUserRepository UserRepository { get; set; }
                public virtual void DisplayNameRules()
                {
                        this.RuleFor(x => x.DisplayName).Length(0, 200);
                }

                public virtual void EmailAddressRules()
                {
                        this.RuleFor(x => x.EmailAddress).Length(0, 400);
                }

                public virtual void ExternalIdRules()
                {
                        this.RuleFor(x => x.ExternalId).Length(0, 400);
                }

                public virtual void ExternalIdentifiersRules()
                {
                }

                public virtual void IdentificationTokenRules()
                {
                        this.RuleFor(x => x.IdentificationToken).NotNull();
                }

                public virtual void IsActiveRules()
                {
                        this.RuleFor(x => x.IsActive).NotNull();
                }

                public virtual void IsServiceRules()
                {
                        this.RuleFor(x => x.IsService).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void UsernameRules()
                {
                        this.RuleFor(x => x.Username).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetUsername).When(x => x ?.Username != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUserRequestModel.Username));
                        this.RuleFor(x => x.Username).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetUsername(ApiUserRequestModel model,  CancellationToken cancellationToken)
                {
                        User record = await this.UserRepository.GetUsername(model.Username);

                        if (record == null || record.Id == this.existingRecordId)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>fab78e431539cf3c8e930dd19a7fb9ac</Hash>
</Codenesium>*/