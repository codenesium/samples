using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiArtifactRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiArtifactRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiArtifactRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>e3d49cbd67bbc9e190980cad79b4aeb5</Hash>
</Codenesium>*/