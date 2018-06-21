using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiPersonCreditCardRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonCreditCardRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonCreditCardRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>34797ec4c22ce59c731bcee5c4802149</Hash>
</Codenesium>*/