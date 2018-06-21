using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>fa31bcf4135888fcc51256dc326ca7d8</Hash>
</Codenesium>*/