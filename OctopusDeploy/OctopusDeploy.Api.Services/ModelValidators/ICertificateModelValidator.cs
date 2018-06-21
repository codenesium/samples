using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>e6b9a0e3bfa4b8c9ce6460c059d1d438</Hash>
</Codenesium>*/