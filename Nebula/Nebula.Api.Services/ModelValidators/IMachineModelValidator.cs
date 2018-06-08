using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiMachineRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>3c5aec1d6e469ac65713f406e9917bc8</Hash>
</Codenesium>*/