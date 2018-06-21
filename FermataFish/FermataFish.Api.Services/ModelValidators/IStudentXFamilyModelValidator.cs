using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiStudentXFamilyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStudentXFamilyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentXFamilyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a19f2b77f99817a51d2bb59dd2533ddd</Hash>
</Codenesium>*/