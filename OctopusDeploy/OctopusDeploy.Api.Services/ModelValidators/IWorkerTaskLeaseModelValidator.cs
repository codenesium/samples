using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>8e37583964c7e559e892f51058cde231</Hash>
</Codenesium>*/