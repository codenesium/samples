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
        public abstract class AbstractApiApiKeyRequestModelValidator : AbstractValidator<ApiApiKeyRequestModel>
        {
                private string existingRecordId;

                private IApiKeyRepository apiKeyRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByApiKeyHashed).When(x => x?.ApiKeyHashed != null).WithMessage("Violates unique constraint").WithName(nameof(ApiApiKeyRequestModel.ApiKeyHashed));
                        this.RuleFor(x => x.ApiKeyHashed).Length(0, 200);
                }

                public virtual void CreatedRules()
                {
                }

                public virtual void JSONRules()
                {
                }

                public virtual void UserIdRules()
                {
                        this.RuleFor(x => x.UserId).Length(0, 50);
                }

                private async Task<bool> BeUniqueByApiKeyHashed(ApiApiKeyRequestModel model,  CancellationToken cancellationToken)
                {
                        ApiKey record = await this.apiKeyRepository.ByApiKeyHashed(model.ApiKeyHashed);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>eab72ba6dc58f07fbe2d239b9a6aa6e6</Hash>
</Codenesium>*/