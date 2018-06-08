using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

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
    <Hash>e7b1a1847f162a1baca17266be300f00</Hash>
</Codenesium>*/