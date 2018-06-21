using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductDescriptionRequestModelValidator : AbstractValidator<ApiProductDescriptionRequestModel>
        {
                private int existingRecordId;

                private IProductDescriptionRepository productDescriptionRepository;

                public AbstractApiProductDescriptionRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
                {
                        this.productDescriptionRepository = productDescriptionRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductDescriptionRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).NotNull();
                        this.RuleFor(x => x.Description).Length(0, 400);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>9fdf370456dc156105cd597a3d8077b3</Hash>
</Codenesium>*/