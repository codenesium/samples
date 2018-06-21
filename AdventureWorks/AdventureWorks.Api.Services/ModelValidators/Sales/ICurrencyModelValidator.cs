using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>27f563f01816e067b30a8d48b8155489</Hash>
</Codenesium>*/