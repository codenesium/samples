using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiPersonRefRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPersonRefRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRefRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6454a8c05af9f85905ecfef99b0a8cea</Hash>
</Codenesium>*/