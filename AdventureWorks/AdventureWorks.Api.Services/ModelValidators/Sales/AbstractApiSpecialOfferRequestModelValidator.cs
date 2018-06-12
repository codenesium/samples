using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services

{
        public abstract class AbstractApiSpecialOfferRequestModelValidator: AbstractValidator<ApiSpecialOfferRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSpecialOfferRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CategoryRules()
                {
                        this.RuleFor(x => x.Category).NotNull();
                        this.RuleFor(x => x.Category).Length(0, 50);
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).NotNull();
                        this.RuleFor(x => x.Description).Length(0, 255);
                }

                public virtual void DiscountPctRules()
                {
                        this.RuleFor(x => x.DiscountPct).NotNull();
                }

                public virtual void EndDateRules()
                {
                        this.RuleFor(x => x.EndDate).NotNull();
                }

                public virtual void MaxQtyRules()
                {
                }

                public virtual void MinQtyRules()
                {
                        this.RuleFor(x => x.MinQty).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void StartDateRules()
                {
                        this.RuleFor(x => x.StartDate).NotNull();
                }

                public virtual void TypeRules()
                {
                        this.RuleFor(x => x.Type).NotNull();
                        this.RuleFor(x => x.Type).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>dff200dfdd7b072dc6c3e7a29424e7a8</Hash>
</Codenesium>*/