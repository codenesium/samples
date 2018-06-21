using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiTeacherSkillRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>fa5ed7f4ace5d6ca7d7a9718f583a48d</Hash>
</Codenesium>*/