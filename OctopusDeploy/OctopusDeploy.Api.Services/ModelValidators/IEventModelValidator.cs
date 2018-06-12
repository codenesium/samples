using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiEventRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiEventRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>4801f309d314cd12bf7ee1508ee2c72a</Hash>
</Codenesium>*/