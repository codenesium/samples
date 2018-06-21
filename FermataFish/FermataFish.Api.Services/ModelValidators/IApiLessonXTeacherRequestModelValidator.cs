using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiLessonXTeacherRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLessonXTeacherRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXTeacherRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c160f0863268797ddbfce1a24652c59c</Hash>
</Codenesium>*/