using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiStudentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>5e3e9d059f4c88e23b06f17914b079e9</Hash>
</Codenesium>*/