using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiEventRelatedDocumentRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEventRelatedDocumentRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRelatedDocumentRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1ad6eb25c0ed1d6b7578eca847713897</Hash>
</Codenesium>*/