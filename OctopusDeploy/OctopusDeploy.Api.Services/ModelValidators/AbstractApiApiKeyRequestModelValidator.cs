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
        public abstract class AbstractApiApiKeyRequestModelValidator: AbstractValidator<ApiApiKeyRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiApiKeyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiApiKeyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IApiKeyRepository ApiKeyRepository { get; set; }
                public virtual void ApiKeyHashedRules()
                {
                        this.RuleFor(x => x.ApiKeyHashed).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetApiKeyHashed).When(x => x ?.ApiKeyHashed != null).WithMessage("Violates unique constraint").WithName(nameof(ApiApiKeyRequestModel.ApiKeyHashed));
                        this.RuleFor(x => x.ApiKeyHashed).Length(0, 200);
                }

                public virtual void CreatedRules()
                {
                        this.RuleFor(x => x.Created).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void UserIdRules()
                {
                        this.RuleFor(x => x.UserId).NotNull();
                        this.RuleFor(x => x.UserId).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetApiKeyHashed(ApiApiKeyRequestModel model,  CancellationToken cancellationToken)
                {
                        ApiKey record = await this.ApiKeyRepository.GetApiKeyHashed(model.ApiKeyHashed);

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
    <Hash>79f36e4ca7ff33b7e217bad459235a2e</Hash>
</Codenesium>*/