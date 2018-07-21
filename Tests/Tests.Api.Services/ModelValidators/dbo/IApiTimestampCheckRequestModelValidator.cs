using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiTimestampCheckRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTimestampCheckRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTimestampCheckRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>75927b8afdf4d4abbdecfea8a5527c77</Hash>
</Codenesium>*/