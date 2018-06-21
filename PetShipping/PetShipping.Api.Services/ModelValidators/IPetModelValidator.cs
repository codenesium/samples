using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IApiPetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>9e04410a450332746829d5850a324351</Hash>
</Codenesium>*/