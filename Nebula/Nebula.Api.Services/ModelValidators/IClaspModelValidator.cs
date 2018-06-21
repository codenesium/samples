using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiClaspRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a4588c766a2a4ed6cd2c0600563889c5</Hash>
</Codenesium>*/