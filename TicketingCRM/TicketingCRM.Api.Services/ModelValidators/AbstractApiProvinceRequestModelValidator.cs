using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiProvinceRequestModelValidator: AbstractValidator<ApiProvinceRequestModel>
        {
                private int existingRecordId;

                IProvinceRepository provinceRepository;

                public AbstractApiProvinceRequestModelValidator(IProvinceRepository provinceRepository)
                {
                        this.provinceRepository = provinceRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiProvinceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CountryIdRules()
                {
                        this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                private async Task<bool> BeValidCountry(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.provinceRepository.GetCountry(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>39592990c8ed14213a4a3145392b00cf</Hash>
</Codenesium>*/