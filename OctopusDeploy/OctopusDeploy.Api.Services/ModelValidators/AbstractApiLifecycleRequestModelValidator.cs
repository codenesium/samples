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
        public abstract class AbstractApiLifecycleRequestModelValidator: AbstractValidator<ApiLifecycleRequestModel>
        {
                private string existingRecordId;

                ILifecycleRepository lifecycleRepository;

                public AbstractApiLifecycleRequestModelValidator(ILifecycleRepository lifecycleRepository)
                {
                        this.lifecycleRepository = lifecycleRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiLifecycleRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLifecycleRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiLifecycleRequestModel model,  CancellationToken cancellationToken)
                {
                        Lifecycle record = await this.lifecycleRepository.GetName(model.Name);

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
    <Hash>d970c2b955c619917069078f504d2834</Hash>
</Codenesium>*/