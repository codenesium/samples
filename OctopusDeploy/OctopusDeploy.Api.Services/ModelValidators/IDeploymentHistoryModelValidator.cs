using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiDeploymentHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>36871f1f337f90f4b87d719899f6c5a6</Hash>
</Codenesium>*/