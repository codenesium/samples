using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiClientCommunicationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1bfbd6c34da70385b534f0e0c2cc243d</Hash>
</Codenesium>*/