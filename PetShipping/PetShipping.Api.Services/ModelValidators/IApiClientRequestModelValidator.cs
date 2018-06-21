using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiClientRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiClientRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>3a4da7b3fd30c92b46ff04aaa4ba9082</Hash>
</Codenesium>*/