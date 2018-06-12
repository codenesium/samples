using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiUserRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>cebe9386a47aabe2f3186940863ddfe3</Hash>
</Codenesium>*/