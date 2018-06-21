using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiTagsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTagsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a6f9b29fe89121f50d8872c0d2da6a3f</Hash>
</Codenesium>*/