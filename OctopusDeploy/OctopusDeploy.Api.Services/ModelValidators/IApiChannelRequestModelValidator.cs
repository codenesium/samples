using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>2920686a9585e01fc393837a35938cef</Hash>
</Codenesium>*/