using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiVendorRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVendorRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2187fa604a9ce3ac3bdb5e0268c5d4a4</Hash>
</Codenesium>*/