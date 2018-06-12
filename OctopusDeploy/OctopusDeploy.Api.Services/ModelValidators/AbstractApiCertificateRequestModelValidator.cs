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
        public abstract class AbstractApiCertificateRequestModelValidator: AbstractValidator<ApiCertificateRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiCertificateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCertificateRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ArchivedRules()
                {
                }

                public virtual void CreatedRules()
                {
                        this.RuleFor(x => x.Created).NotNull();
                }

                public virtual void DataVersionRules()
                {
                        this.RuleFor(x => x.DataVersion).NotNull();
                }

                public virtual void EnvironmentIdsRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void NotAfterRules()
                {
                        this.RuleFor(x => x.NotAfter).NotNull();
                }

                public virtual void SubjectRules()
                {
                        this.RuleFor(x => x.Subject).NotNull();
                }

                public virtual void TenantIdsRules()
                {
                }

                public virtual void TenantTagsRules()
                {
                }

                public virtual void ThumbprintRules()
                {
                        this.RuleFor(x => x.Thumbprint).NotNull();
                        this.RuleFor(x => x.Thumbprint).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>1f847e5fcf693e2559dd3cd2816da821</Hash>
</Codenesium>*/