using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiFamilyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c0a18adaf06409df1bd10cb484079494</Hash>
</Codenesium>*/