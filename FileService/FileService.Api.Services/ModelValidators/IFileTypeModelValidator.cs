using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.Services
{
        public interface IApiFileTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>180b0dbc652b1534fddb1d2c9364addd</Hash>
</Codenesium>*/