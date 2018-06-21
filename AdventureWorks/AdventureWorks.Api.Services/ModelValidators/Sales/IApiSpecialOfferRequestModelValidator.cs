using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSpecialOfferRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>996c9bef4e15d88fa907edb8e261121f</Hash>
</Codenesium>*/