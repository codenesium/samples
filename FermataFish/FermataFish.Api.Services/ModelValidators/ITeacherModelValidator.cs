using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiTeacherRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>427454fe251e242481d0cadb014b2426</Hash>
</Codenesium>*/