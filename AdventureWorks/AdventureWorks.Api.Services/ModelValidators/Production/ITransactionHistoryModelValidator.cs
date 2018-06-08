using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>a091d900520ba39fe08643a9d60b0ba8</Hash>
</Codenesium>*/