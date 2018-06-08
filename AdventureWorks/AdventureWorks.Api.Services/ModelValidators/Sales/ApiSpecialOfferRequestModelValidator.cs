using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSpecialOfferRequestModelValidator: AbstractApiSpecialOfferRequestModelValidator, IApiSpecialOfferRequestModelValidator
        {
                public ApiSpecialOfferRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferRequestModel model)
                {
                        this.CategoryRules();
                        this.DescriptionRules();
                        this.DiscountPctRules();
                        this.EndDateRules();
                        this.MaxQtyRules();
                        this.MinQtyRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.StartDateRules();
                        this.TypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferRequestModel model)
                {
                        this.CategoryRules();
                        this.DescriptionRules();
                        this.DiscountPctRules();
                        this.EndDateRules();
                        this.MaxQtyRules();
                        this.MinQtyRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.StartDateRules();
                        this.TypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>ef62b235b2e4a7a91bf9d01da631c624</Hash>
</Codenesium>*/