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

                public ValidationResult Validate(ApiDeploymentEnvironmentRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentEnvironmentRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IDeploymentEnvironmentRepository DeploymentEnvironmentRepository { get; set; }
                public virtual void DataVersionRules()
                {
                        this.RuleFor(x => x.DataVersion).NotNull();
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
                        this.RuleFor(x => x.SortOrder).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiDeploymentEnvironmentRequestModel model,  CancellationToken cancellationToken)
                {
                        DeploymentEnvironment record = await this.DeploymentEnvironmentRepository.GetName(model.Name);

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
    <Hash>689ba5ff17527bc64f455bff87f6f60f</Hash>
</Codenesium>*/