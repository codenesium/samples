using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>2443d8d1cf4e0ec93ef5b4f7de6dd5bb</Hash>
</Codenesium>*/