using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiLessonXStudentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLessonXStudentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiLessonXStudentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>6160a353a7999a7db863873df5175fd6</Hash>
</Codenesium>*/