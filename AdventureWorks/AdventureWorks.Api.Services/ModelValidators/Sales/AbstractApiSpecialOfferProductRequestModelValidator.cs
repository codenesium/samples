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

                ISpecialOfferProductRepository specialOfferProductRepository;

                public AbstractApiSpecialOfferProductRequestModelValidator(ISpecialOfferProductRepository specialOfferProductRepository)
                {
                        this.specialOfferProductRepository = specialOfferProductRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferProductRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        var record = await this.specialOfferProductRepository.GetSpecialOffer(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>ecf8bc1e51c82db092fc73271f7bd9c6</Hash>
</Codenesium>*/