using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiRowVersionCheckRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiRowVersionCheckRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiRowVersionCheckRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>92d0fa55114dda2c37aafb34992ac01b</Hash>
</Codenesium>*/