using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductModelIllustrationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1fd3d7009d6f8b71490d17618bd71e3d</Hash>
</Codenesium>*/