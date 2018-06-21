using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>0df3f93258f7f889497afc695b5d1929</Hash>
</Codenesium>*/