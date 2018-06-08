using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

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
    <Hash>37c699a750d79270760f9550bcdd82c5</Hash>
</Codenesium>*/