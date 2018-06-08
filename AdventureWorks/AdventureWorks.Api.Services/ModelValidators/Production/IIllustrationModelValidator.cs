using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiIllustrationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>e816d23a387e0d72becb2e53fbbd15af</Hash>
</Codenesium>*/