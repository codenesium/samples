using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSalesPersonRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f72bcc3ab5ea84d0a0eb3295fb5b2bc7</Hash>
</Codenesium>*/