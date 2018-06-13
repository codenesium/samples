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
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeValidSpecialOffer(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpecialOfferRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>12a9d7e1fd022b833dd286fd3e161d65</Hash>
</Codenesium>*/