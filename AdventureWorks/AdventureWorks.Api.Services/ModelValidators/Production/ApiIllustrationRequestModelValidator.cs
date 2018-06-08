using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiIllustrationRequestModelValidator: AbstractApiIllustrationRequestModelValidator, IApiIllustrationRequestModelValidator
        {
                public ApiIllustrationRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model)
                {
                        this.DiagramRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model)
                {
                        this.DiagramRules();
                        this.ModifiedDateRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>b8844045807bbfe3106f7f839e723ff3</Hash>
</Codenesium>*/