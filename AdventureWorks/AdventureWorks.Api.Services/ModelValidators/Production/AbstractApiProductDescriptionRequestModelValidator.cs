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
        public abstract class AbstractApiProductDescriptionRequestModelValidator: AbstractValidator<ApiProductDescriptionRequestModel>
        {
                private int existingRecordId;

                IProductDescriptionRepository productDescriptionRepository;

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
    <Hash>13555de96455dbcd205f7c43b16b99f4</Hash>
</Codenesium>*/