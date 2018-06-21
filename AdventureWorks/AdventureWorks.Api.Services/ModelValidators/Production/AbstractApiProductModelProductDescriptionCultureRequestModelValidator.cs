using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiProductModelProductDescriptionCultureRequestModelValidator : AbstractValidator<ApiProductModelProductDescriptionCultureRequestModel>
        {
                private int existingRecordId;

                private IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;

                public AbstractApiProductModelProductDescriptionCultureRequestModelValidator(IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository)
                {
                        this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductModelProductDescriptionCultureRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CultureIDRules()
                {
                        this.RuleFor(x => x.CultureID).NotNull();
                        this.RuleFor(x => x.CultureID).Length(0, 6);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ProductDescriptionIDRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>695a22e40fd13f04792d792815d9098e</Hash>
</Codenesium>*/