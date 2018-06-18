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
        public abstract class AbstractApiDeploymentEnvironmentRequestModelValidator: AbstractValidator<ApiDeploymentEnvironmentRequestModel>
        {
                private string existingRecordId;

                IDeploymentEnvironmentRepository deploymentEnvironmentRepository;

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
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiDeploymentEnvironmentRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiDeploymentEnvironmentRequestModel model,  CancellationToken cancellationToken)
                {
                        DeploymentEnvironment record = await this.deploymentEnvironmentRepository.GetName(model.Name);

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
    <Hash>60397752f30d85eef1e0c3a3bd535eab</Hash>
</Codenesium>*/