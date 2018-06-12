using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiInvitationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiInvitationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiInvitationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>6dca1bbc237a9700f5d8d9e5b701adf8</Hash>
</Codenesium>*/