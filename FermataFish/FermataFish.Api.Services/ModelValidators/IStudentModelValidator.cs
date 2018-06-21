using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiStudentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>04f3c32b98c520922a760f8b6e984be1</Hash>
</Codenesium>*/