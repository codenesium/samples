using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>42c5127baaf406dd25af43150008b97f</Hash>
</Codenesium>*/