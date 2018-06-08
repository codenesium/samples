using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSpecialOfferProductRequestModelValidator: AbstractApiSpecialOfferProductRequestModelValidator, IApiSpecialOfferProductRequestModelValidator
        {
                public ApiSpecialOfferProductRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>9828d243b750831ac7c102822b0b01d5</Hash>
</Codenesium>*/