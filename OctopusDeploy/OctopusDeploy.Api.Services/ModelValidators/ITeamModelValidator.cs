using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTeamRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTeamRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>87e3d7105f92f783b309f8e627ae4eb0</Hash>
</Codenesium>*/