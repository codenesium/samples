using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiCountryRequestModelValidator : AbstractValidator<ApiCountryRequestModel>
        {
                private int existingRecordId;

                private ICountryRepository countryRepository;

                public AbstractApiCountryRequestModelValidator(ICountryRepository countryRepository)
                {
                        this.countryRepository = countryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCountryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>c67dc2f129a29ebb79a22c9c7b5b007c</Hash>
</Codenesium>*/