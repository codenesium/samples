using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiTeamRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTeamRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeamRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e71719ac5711dc7748be0ccee7407d7a</Hash>
</Codenesium>*/