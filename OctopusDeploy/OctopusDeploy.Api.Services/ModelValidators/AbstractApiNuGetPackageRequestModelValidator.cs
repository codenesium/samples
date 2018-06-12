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
        public abstract class AbstractApiNuGetPackageRequestModelValidator: AbstractValidator<ApiNuGetPackageRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiNuGetPackageRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiNuGetPackageRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void PackageIdRules()
                {
                        this.RuleFor(x => x.PackageId).NotNull();
                        this.RuleFor(x => x.PackageId).Length(0, 100);
                }

                public virtual void VersionRules()
                {
                        this.RuleFor(x => x.Version).NotNull();
                        this.RuleFor(x => x.Version).Length(0, 349);
                }

                public virtual void VersionBuildRules()
                {
                        this.RuleFor(x => x.VersionBuild).NotNull();
                }

                public virtual void VersionMajorRules()
                {
                        this.RuleFor(x => x.VersionMajor).NotNull();
                }

                public virtual void VersionMinorRules()
                {
                        this.RuleFor(x => x.VersionMinor).NotNull();
                }

                public virtual void VersionRevisionRules()
                {
                        this.RuleFor(x => x.VersionRevision).NotNull();
                }

                public virtual void VersionSpecialRules()
                {
                        this.RuleFor(x => x.VersionSpecial).Length(0, 250);
                }
        }
}

/*<Codenesium>
    <Hash>afdbbb5ecb25a72aabdaab7b462b7bfe</Hash>
</Codenesium>*/