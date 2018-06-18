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
        public abstract class AbstractApiTenantRequestModelValidator: AbstractValidator<ApiTenantRequestModel>
        {
                private string existingRecordId;

                ITenantRepository tenantRepository;

                public AbstractApiTenantRequestModelValidator(ITenantRepository tenantRepository)
                {
                        this.tenantRepository = tenantRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTenantRequestModel model, string id)
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTenantRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void ProjectIdsRules()
                {
                        this.RuleFor(x => x.ProjectIds).NotNull();
                }

                public virtual void TenantTagsRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiTenantRequestModel model,  CancellationToken cancellationToken)
                {
                        Tenant record = await this.tenantRepository.GetName(model.Name);

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
    <Hash>1ebb05c7f6d73617c28a589bfe158223</Hash>
</Codenesium>*/