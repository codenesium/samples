using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiChannelRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiChannelRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiChannelRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>5618eb958d8ac10ea03cf46fb189d77f</Hash>
</Codenesium>*/