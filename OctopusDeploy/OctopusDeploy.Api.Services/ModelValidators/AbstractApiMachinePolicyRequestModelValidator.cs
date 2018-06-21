using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiMachinePolicyRequestModelValidator : AbstractValidator<ApiMachinePolicyRequestModel>
        {
                private string existingRecordId;

                private IMachinePolicyRepository machinePolicyRepository;

                public AbstractApiMachinePolicyRequestModelValidator(IMachinePolicyRepository machinePolicyRepository)
                {
                        this.machinePolicyRepository = machinePolicyRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiMachinePolicyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsDefaultRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiMachinePolicyRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                private async Task<bool> BeUniqueGetName(ApiMachinePolicyRequestModel model,  CancellationToken cancellationToken)
                {
                        MachinePolicy record = await this.machinePolicyRepository.GetName(model.Name);

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
    <Hash>efe587a7f22608b186a7b13ac9966184</Hash>
</Codenesium>*/