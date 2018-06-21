using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPhoneNumberTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>ba78290eab462855df7a239d901e87fb</Hash>
</Codenesium>*/