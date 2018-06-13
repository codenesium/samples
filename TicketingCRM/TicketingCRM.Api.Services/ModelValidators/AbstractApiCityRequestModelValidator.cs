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
        public abstract class AbstractApiCityRequestModelValidator: AbstractValidator<ApiCityRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiCityRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCityRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IProvinceRepository ProvinceRepository { get; set; }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void ProvinceIdRules()
                {
                        this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvince).When(x => x ?.ProvinceId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidProvince(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.ProvinceRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>e26354060c104f24d82eb91dafd5585f</Hash>
</Codenesium>*/