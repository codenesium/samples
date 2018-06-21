using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>0ab8e056fda41c57342fb925421256d1</Hash>
</Codenesium>*/