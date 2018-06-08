using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>dbe3039cdcea26d8e02c0548e3f4b112</Hash>
</Codenesium>*/