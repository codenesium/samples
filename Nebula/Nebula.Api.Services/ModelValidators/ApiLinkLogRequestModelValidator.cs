using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ApiLinkLogRequestModelValidator: AbstractApiLinkLogRequestModelValidator, IApiLinkLogRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2b62ea17b46b0aeb63c424957e6e8256</Hash>
</Codenesium>*/