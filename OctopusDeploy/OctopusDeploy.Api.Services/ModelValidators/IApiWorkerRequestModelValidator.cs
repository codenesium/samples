using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiWorkerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiWorkerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiWorkerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>56a1e77fc4747a7f4ea6384dc2d8135d</Hash>
</Codenesium>*/