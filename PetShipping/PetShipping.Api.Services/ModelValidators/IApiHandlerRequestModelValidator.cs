using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiHandlerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiHandlerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6004c5dd009ecdc5fe7872f09efef5b2</Hash>
</Codenesium>*/