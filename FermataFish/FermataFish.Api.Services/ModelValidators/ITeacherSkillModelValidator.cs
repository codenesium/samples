using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>68941018336fb90d210aaf058e3817ee</Hash>
</Codenesium>*/