using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiWorkerTaskLeaseRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiWorkerTaskLeaseRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerTaskLeaseRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>3b35d61e74dabfef0efd080bbce4a5b0</Hash>
</Codenesium>*/