using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiTeacherXTeacherSkillRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTeacherXTeacherSkillRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherXTeacherSkillRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>548bbf37d8ee4bf9b74e7269e6c1c4a0</Hash>
</Codenesium>*/