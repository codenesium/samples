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
        public abstract class AbstractApiAccountRequestModelValidator: AbstractValidator<ApiAccountRequestModel>
        {
                private string existingRecordId;

                IAccountRepository accountRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAccountRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void TenantIdsRules()
                {
                }

                public virtual void TenantTagsRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiAccountRequestModel model,  CancellationToken cancellationToken)
                {
                        Account record = await this.accountRepository.GetName(model.Name);

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
    <Hash>c55cbea28a92c55194e1605dfd0b9483</Hash>
</Codenesium>*/