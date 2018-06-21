using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>43010ab886155c2c25423c03e4f00d6e</Hash>
</Codenesium>*/