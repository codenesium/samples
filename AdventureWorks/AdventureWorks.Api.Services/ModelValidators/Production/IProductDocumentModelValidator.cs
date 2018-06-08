using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductDocumentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductDocumentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDocumentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>32f07d7502c0b728e3dfb931596fff55</Hash>
</Codenesium>*/