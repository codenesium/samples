using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>6bcaef5e6e6dd454b2415130833d40fd</Hash>
</Codenesium>*/