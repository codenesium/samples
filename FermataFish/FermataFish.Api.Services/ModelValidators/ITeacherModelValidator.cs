using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>8bcf73b3ea5376c42e9b73280372ce7a</Hash>
</Codenesium>*/