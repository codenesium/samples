using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>a41972aef0fb0fe4a7a5e9ceb94e7da2</Hash>
</Codenesium>*/