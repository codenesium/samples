using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiDestinationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>4cf83b43b7117e539d924247568f7005</Hash>
</Codenesium>*/