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
        public abstract class AbstractApiShipMethodRequestModelValidator : AbstractValidator<ApiShipMethodRequestModel>
        {
                private int existingRecordId;

                private IShipMethodRepository shipMethodRepository;

                public AbstractApiShipMethodRequestModelValidator(IShipMethodRepository shipMethodRepository)
                {
                        this.shipMethodRepository = shipMethodRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiShipMethodRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void ShipBaseRules()
                {
                }

                public virtual void ShipRateRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiShipMethodRequestModel model,  CancellationToken cancellationToken)
                {
                        ShipMethod record = await this.shipMethodRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.ShipMethodID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>abb77eb8b5feac8a94bfa17360d02183</Hash>
</Codenesium>*/