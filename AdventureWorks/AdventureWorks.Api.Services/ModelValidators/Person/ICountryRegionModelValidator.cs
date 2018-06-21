using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCountryRegionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>b61be651d1f780dcaf33bc859293548e</Hash>
</Codenesium>*/