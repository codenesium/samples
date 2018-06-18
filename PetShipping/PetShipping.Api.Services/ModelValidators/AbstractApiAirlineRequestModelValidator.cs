using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiAirlineRequestModelValidator: AbstractValidator<ApiAirlineRequestModel>
        {
                private int existingRecordId;

                IAirlineRepository airlineRepository;

                public AbstractApiAirlineRequestModelValidator(IAirlineRepository airlineRepository)
                {
                        this.airlineRepository = airlineRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiAirlineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>c0fee943c8fd0f295ae02139abd7fa54</Hash>
</Codenesium>*/