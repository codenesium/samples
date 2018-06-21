using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>cab7305bde4c1e107c79750da0d805aa</Hash>
</Codenesium>*/