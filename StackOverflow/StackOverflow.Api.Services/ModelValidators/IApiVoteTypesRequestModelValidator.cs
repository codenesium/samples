using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiVoteTypesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVoteTypesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiVoteTypesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e1ffda3890bcd03ac91581404d81f054</Hash>
</Codenesium>*/