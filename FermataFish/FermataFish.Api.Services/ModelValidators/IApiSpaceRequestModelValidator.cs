using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiSpaceRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>f8fe2013c413d227d9f8862d63f647c5</Hash>
</Codenesium>*/