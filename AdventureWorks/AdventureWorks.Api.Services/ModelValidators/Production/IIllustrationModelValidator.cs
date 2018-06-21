using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>6295775c232a851cf1cf092542f6248e</Hash>
</Codenesium>*/