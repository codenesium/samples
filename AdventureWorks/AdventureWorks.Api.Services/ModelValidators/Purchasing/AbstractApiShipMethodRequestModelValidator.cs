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
        public abstract class AbstractApiShipMethodRequestModelValidator: AbstractValidator<ApiShipMethodRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiShipMethodRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiShipMethodRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IShipMethodRepository ShipMethodRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodRequestModel.Name));
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

                private async Task<bool> BeUniqueGetName(ApiShipMethodRequestModel model,  CancellationToken cancellationToken)
                {
                        ShipMethod record = await this.ShipMethodRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.ShipMethodID == this.existingRecordId))
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
    <Hash>d7b76e5ac68bb809d85d97a8ff54bfb9</Hash>
</Codenesium>*/