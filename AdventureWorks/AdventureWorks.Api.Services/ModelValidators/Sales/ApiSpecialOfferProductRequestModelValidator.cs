using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSpecialOfferProductRequestModelValidator : AbstractApiSpecialOfferProductRequestModelValidator, IApiSpecialOfferProductRequestModelValidator
        {
                public ApiSpecialOfferProductRequestModelValidator(ISpecialOfferProductRepository specialOfferProductRepository)
                        : base(specialOfferProductRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.RowguidRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>15ff035fba97602158816f3203233eea</Hash>
</Codenesium>*/