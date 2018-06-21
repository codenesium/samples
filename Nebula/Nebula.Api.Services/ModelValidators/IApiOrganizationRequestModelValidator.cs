using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public interface IApiOrganizationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>1457772479cb97bc6056a61887a0581f</Hash>
</Codenesium>*/