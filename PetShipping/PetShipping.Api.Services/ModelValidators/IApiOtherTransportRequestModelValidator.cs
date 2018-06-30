using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiOtherTransportRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiOtherTransportRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiOtherTransportRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>952dea3e7263e1ca55fc3dda206fbdcc</Hash>
</Codenesium>*/