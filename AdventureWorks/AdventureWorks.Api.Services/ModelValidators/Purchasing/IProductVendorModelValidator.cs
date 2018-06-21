using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>e279394a9690d1183d4dee9a4d6c2323</Hash>
</Codenesium>*/