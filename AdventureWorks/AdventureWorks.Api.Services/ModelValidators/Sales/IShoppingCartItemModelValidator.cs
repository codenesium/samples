using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiShoppingCartItemRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiShoppingCartItemRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiShoppingCartItemRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>ae00595f92b7e5a6ae97eb558e3b8db5</Hash>
</Codenesium>*/