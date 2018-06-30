using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiPostsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPostsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>274e7a6dc7670d2daf5fa8a81130db30</Hash>
</Codenesium>*/