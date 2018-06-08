using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductVendorRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f4df99097fff7e080314c3ef2178736b</Hash>
</Codenesium>*/