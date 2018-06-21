using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiScrapReasonRequestModelValidator : AbstractApiScrapReasonRequestModelValidator, IApiScrapReasonRequestModelValidator
        {
                public ApiScrapReasonRequestModelValidator(IScrapReasonRepository scrapReasonRepository)
                        : base(scrapReasonRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(short id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>def0b00b5cd9742f892b12aca9f09f8a</Hash>
</Codenesium>*/