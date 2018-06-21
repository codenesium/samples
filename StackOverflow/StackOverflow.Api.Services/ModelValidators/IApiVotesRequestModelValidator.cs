using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiVotesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVotesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiVotesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e207eb3e54fc1e4e9617db6b59876f05</Hash>
</Codenesium>*/