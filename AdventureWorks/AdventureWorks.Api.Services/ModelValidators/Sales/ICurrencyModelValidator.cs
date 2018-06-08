using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiCurrencyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>c46eba48ae5d750ca94bb561b1afe8d6</Hash>
</Codenesium>*/