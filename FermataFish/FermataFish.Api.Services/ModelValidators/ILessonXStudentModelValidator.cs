using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>8abcf8ce0b85cb410fe9a3fda028a0bf</Hash>
</Codenesium>*/