using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiAddressRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7e35f397f98a810b49d8cfefdee1299a</Hash>
</Codenesium>*/