using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>905fdffa1e0db69bf97166d68ba03287</Hash>
</Codenesium>*/