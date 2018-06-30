using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>c8ec1b60da460b83c872a254b32eea8a</Hash>
</Codenesium>*/