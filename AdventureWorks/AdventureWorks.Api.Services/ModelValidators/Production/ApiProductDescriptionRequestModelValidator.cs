using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiProductDescriptionRequestModelValidator: AbstractApiProductDescriptionRequestModelValidator, IApiProductDescriptionRequestModelValidator
        {
                public ApiProductDescriptionRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
                        : base(productDescriptionRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model)
                {
                        this.DescriptionRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model)
                {
                        this.DescriptionRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>98c2505f197d5d45dbbe10c45dfa18fe</Hash>
</Codenesium>*/