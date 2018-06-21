using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiAdminRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8be54ff9985250140e50c97bbcd8c0aa</Hash>
</Codenesium>*/