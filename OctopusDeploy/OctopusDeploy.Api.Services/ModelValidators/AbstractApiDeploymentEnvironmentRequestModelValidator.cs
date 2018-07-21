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
        public abstract class AbstractApiDeploymentEnvironmentRequestModelValidator : AbstractValidator<ApiDeploymentEnvironmentRequestModel>
        {
                private string existingRecordId;

                private IDeploymentEnvironmentRepository deploymentEnvironmentRepository;

                public AbstractApiDeploymentEnvironmentRequestModelValidator(IDeploymentEnvironmentRepository deploymentEnvironmentRepository)
                {
                        this.deploymentEnvironmentRepository = deploymentEnvironmentRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentEnvironmentRequestModel model, string id)
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeploymentEnvironmentRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiDeploymentEnvironmentRequestModel model,  CancellationToken cancellationToken)
                {
                        DeploymentEnvironment record = await this.deploymentEnvironmentRepository.ByName(model.Name);

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
    <Hash>548a1dd109bab4f822be99cdd5fc23da</Hash>
</Codenesium>*/