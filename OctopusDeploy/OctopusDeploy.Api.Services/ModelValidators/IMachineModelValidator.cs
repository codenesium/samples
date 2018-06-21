using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiMachineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>2262ad7b0dcf103a0b735faa9792c3a5</Hash>
</Codenesium>*/