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
        public abstract class AbstractApiSpecialOfferProductRequestModelValidator: AbstractValidator<ApiSpecialOfferProductRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSpecialOfferProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISpecialOfferRepository SpecialOfferRepository { get; set; }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).NotNull();
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                private async Task<bool> BeValidSpecialOffer(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpecialOfferRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>607621a5308c0305a0d256062468ab47</Hash>
</Codenesium>*/