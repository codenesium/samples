using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCreditCardRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCreditCardRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCreditCardRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e3f68ee75f25575c655665cf6d5006cc</Hash>
</Codenesium>*/