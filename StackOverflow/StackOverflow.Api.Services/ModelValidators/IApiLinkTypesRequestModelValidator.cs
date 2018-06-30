using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiLinkTypesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLinkTypesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c28227bd7a9ed09acf8409376f4b84cf</Hash>
</Codenesium>*/