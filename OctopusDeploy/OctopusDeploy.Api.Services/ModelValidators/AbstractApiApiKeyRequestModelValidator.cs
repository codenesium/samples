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

                IApiKeyRepository apiKeyRepository;

                public AbstractApiApiKeyRequestModelValidator(IApiKeyRepository apiKeyRepository)
                {
                        this.apiKeyRepository = apiKeyRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiApiKeyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ApiKeyHashedRules()
                {
                        this.RuleFor(x => x.ApiKeyHashed).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetApiKeyHashed).When(x => x ?.ApiKeyHashed != null).WithMessage("Violates unique constraint").WithName(nameof(ApiApiKeyRequestModel.ApiKeyHashed));
                        this.RuleFor(x => x.ApiKeyHashed).Length(0, 200);
                }

                public virtual void CreatedRules()
                {
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
                        ApiKey record = await this.apiKeyRepository.GetApiKeyHashed(model.ApiKeyHashed);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
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
    <Hash>0e271c230c0ab33d49f694158f5e75f2</Hash>
</Codenesium>*/