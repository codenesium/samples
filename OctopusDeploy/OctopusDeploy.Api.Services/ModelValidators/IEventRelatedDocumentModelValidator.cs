using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>33af3fc7000c9b2518b2679f5f0e25eb</Hash>
</Codenesium>*/