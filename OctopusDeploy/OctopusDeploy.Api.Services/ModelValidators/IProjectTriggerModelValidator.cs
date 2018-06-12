using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>852b1fa4de2c4d882ad281393f1bf065</Hash>
</Codenesium>*/