using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface IApiSpaceXSpaceFeatureRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c6b7f69fe3ef2b12ca468f6ad9dc8b46</Hash>
</Codenesium>*/