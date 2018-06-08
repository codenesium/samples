using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiChainRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiChainRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c63f9685ae9fa9276b2d87eb24e37994</Hash>
</Codenesium>*/