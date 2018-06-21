using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiPostHistoryTypesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2a77981c8c2c78a287d61b312252c087</Hash>
</Codenesium>*/