using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>e82a84c5d5f63fca92003071247231fa</Hash>
</Codenesium>*/