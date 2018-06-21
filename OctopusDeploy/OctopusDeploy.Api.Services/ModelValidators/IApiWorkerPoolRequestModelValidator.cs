using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiWorkerPoolRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiWorkerPoolRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerPoolRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>0edc85f8f87c2e530c4f3875acc3de60</Hash>
</Codenesium>*/