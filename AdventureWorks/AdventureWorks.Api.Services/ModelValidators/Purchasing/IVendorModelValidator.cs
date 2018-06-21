using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>d7f3a16b1695fc7873c471b8d5ea398d</Hash>
</Codenesium>*/