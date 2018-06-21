using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>f5d36871b3fee74407088b056825f18b</Hash>
</Codenesium>*/