using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>1dfa0ff995ac80bcdf58ff7d4bb0d054</Hash>
</Codenesium>*/