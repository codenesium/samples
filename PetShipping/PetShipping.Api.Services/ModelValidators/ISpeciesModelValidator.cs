using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Services
{
        public interface IApiSpeciesRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>afbbaaeb7059f23a3d30d78971040002</Hash>
</Codenesium>*/