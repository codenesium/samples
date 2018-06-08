using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Services
{
        public interface IApiVersionInfoRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(long id);
        }
}

/*<Codenesium>
    <Hash>46fd206fbb1c423b976611e693e39787</Hash>
</Codenesium>*/