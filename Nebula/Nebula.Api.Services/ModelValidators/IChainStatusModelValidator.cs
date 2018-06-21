using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiChainStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>76871f549cd56d6c5345947b8bbfe72e</Hash>
</Codenesium>*/