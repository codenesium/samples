using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

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
    <Hash>47c4cdfac68b2f9d9757ccf13cc00923</Hash>
</Codenesium>*/