using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
        public class ApiLinkLogRequestModelValidator : AbstractApiLinkLogRequestModelValidator, IApiLinkLogRequestModelValidator
        {
                public ApiLinkLogRequestModelValidator(ILinkLogRepository linkLogRepository)
                        : base(linkLogRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model)
                {
                        this.DateEnteredRules();
                        this.LinkIdRules();
                        this.LogRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model)
                {
                        this.DateEnteredRules();
                        this.LinkIdRules();
                        this.LogRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>059ddfb71c8a659f1c23e14b90c3367c</Hash>
</Codenesium>*/