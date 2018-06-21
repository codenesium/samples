using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiTransactionHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>8bdaaa9d5f89149e78f6e4567c170d1f</Hash>
</Codenesium>*/