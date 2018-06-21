using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiPostLinksRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPostLinksRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinksRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a967ab1865370229ee514f33790c5077</Hash>
</Codenesium>*/