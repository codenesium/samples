using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public interface IApiSaleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2a2513d2a329fa7529c1fb02d23f6ea0</Hash>
</Codenesium>*/