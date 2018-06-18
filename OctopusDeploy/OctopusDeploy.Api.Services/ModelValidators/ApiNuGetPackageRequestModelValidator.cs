using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiNuGetPackageRequestModelValidator: AbstractApiNuGetPackageRequestModelValidator, IApiNuGetPackageRequestModelValidator
        {
                public ApiNuGetPackageRequestModelValidator(INuGetPackageRepository nuGetPackageRepository)
                        : base(nuGetPackageRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiNuGetPackageRequestModel model)
                {
                        this.JSONRules();
                        this.PackageIdRules();
                        this.VersionRules();
                        this.VersionBuildRules();
                        this.VersionMajorRules();
                        this.VersionMinorRules();
                        this.VersionRevisionRules();
                        this.VersionSpecialRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiNuGetPackageRequestModel model)
                {
                        this.JSONRules();
                        this.PackageIdRules();
                        this.VersionRules();
                        this.VersionBuildRules();
                        this.VersionMajorRules();
                        this.VersionMinorRules();
                        this.VersionRevisionRules();
                        this.VersionSpecialRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b59412e2ed9bb0fa6054e56f06a51b82</Hash>
</Codenesium>*/