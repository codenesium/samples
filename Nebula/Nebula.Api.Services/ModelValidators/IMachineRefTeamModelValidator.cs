using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiMachineRefTeamRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiMachineRefTeamRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiMachineRefTeamRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4a4a8f8c131fea511cde8361060a894c</Hash>
</Codenesium>*/