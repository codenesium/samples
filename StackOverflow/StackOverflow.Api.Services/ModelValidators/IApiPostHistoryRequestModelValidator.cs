using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiPostHistoryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>7a9adfdde58e39ed98df8e0ef5f7885b</Hash>
</Codenesium>*/