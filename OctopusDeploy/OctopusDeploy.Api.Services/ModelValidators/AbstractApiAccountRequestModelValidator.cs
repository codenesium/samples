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
        public abstract class AbstractApiAccountRequestModelValidator : AbstractValidator<ApiAccountRequestModel>
        {
                private string existingRecordId;

                private IAccountRepository accountRepository;

                public AbstractApiAccountRequestModelValidator(IAccountRepository accountRepository)
                {
                        this.accountRepository = accountRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiAccountRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AccountTypeRules()
                {
                        this.RuleFor(x => x.AccountType).NotNull();
                        this.RuleFor(x => x.AccountType).Length(0, 50);
                }

                public virtual void EnvironmentIdsRules()
                {
                        this.RuleFor(x => x.EnvironmentIds).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAccountRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void TenantIdsRules()
                {
                }

                public virtual void TenantTagsRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiAccountRequestModel model,  CancellationToken cancellationToken)
                {
                        Account record = await this.accountRepository.ByName(model.Name);

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
    <Hash>f1df153342884c19f0b389eb39041960</Hash>
</Codenesium>*/