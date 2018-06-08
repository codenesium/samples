using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiTransactionHistoryArchiveRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>62d090af3af34779e9ad21d53cfad139</Hash>
</Codenesium>*/