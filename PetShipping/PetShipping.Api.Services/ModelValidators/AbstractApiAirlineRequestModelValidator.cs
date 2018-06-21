using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiAirlineRequestModelValidator : AbstractValidator<ApiAirlineRequestModel>
        {
                private int existingRecordId;

                private IAirlineRepository airlineRepository;

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
    <Hash>ab4ff3bd7dd209b984fd2145bb18955c</Hash>
</Codenesium>*/