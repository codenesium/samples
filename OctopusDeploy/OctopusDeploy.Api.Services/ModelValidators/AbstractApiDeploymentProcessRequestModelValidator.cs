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
        public abstract class AbstractApiDeploymentProcessRequestModelValidator: AbstractValidator<ApiDeploymentProcessRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiDeploymentProcessRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiDeploymentProcessRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IsFrozenRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void OwnerIdRules()
                {
                        this.RuleFor(x => x.OwnerId).NotNull();
                        this.RuleFor(x => x.OwnerId).Length(0, 150);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                }

                public virtual void VersionRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>65bb464a273b0135b6db51d99fbf2ef3</Hash>
</Codenesium>*/