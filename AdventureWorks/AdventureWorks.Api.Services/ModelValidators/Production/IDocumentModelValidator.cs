using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiDocumentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiDocumentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(Guid id);
        }
}

/*<Codenesium>
    <Hash>12d601eca3961f5ec131158ecaf0102a</Hash>
</Codenesium>*/