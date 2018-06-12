using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiNuGetPackageRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiNuGetPackageRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiNuGetPackageRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>dc83e11890656749fcb705142363d602</Hash>
</Codenesium>*/