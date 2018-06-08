using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

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
    <Hash>326ebd995519e949a411db6fde53129f</Hash>
</Codenesium>*/