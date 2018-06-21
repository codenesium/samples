using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiProjectTriggerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProjectTriggerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectTriggerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>b224e544528702dddbde32be15a4a721</Hash>
</Codenesium>*/