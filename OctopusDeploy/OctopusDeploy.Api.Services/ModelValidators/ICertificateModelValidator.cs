using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiCertificateRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCertificateRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCertificateRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>630381350812bafe0f4be048ba794b13</Hash>
</Codenesium>*/