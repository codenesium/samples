using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>6facd8df2989d02c49250bfb9458a6f9</Hash>
</Codenesium>*/