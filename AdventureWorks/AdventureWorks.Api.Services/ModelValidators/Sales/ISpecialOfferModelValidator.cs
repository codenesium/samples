using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>459e84da1d72c6c19212f1b86b2b8527</Hash>
</Codenesium>*/