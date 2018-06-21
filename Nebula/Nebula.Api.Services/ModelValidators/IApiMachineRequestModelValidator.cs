using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>261a2e4c1a55b06bba85aa0c6a485038</Hash>
</Codenesium>*/