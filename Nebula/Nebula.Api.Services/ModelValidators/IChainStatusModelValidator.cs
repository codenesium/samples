using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

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
    <Hash>de96664b424865296d14d536be8e90e7</Hash>
</Codenesium>*/