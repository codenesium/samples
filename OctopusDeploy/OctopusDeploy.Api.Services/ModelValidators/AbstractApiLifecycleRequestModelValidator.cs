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
        public abstract class AbstractApiLifecycleRequestModelValidator : AbstractValidator<ApiLifecycleRequestModel>
        {
                private string existingRecordId;

                private ILifecycleRepository lifecycleRepository;

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
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiLifecycleRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueByName(ApiLifecycleRequestModel model,  CancellationToken cancellationToken)
                {
                        Lifecycle record = await this.lifecycleRepository.ByName(model.Name);

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
    <Hash>f58ec88db0830ad4160ffb9c1586855c</Hash>
</Codenesium>*/