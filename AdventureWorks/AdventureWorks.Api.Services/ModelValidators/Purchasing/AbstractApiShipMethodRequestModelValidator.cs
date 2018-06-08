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
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void ShipBaseRules()
                {
                        this.RuleFor(x => x.ShipBase).NotNull();
                }

                public virtual void ShipRateRules()
                {
                        this.RuleFor(x => x.ShipRate).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiShipMethodRequestModel model,  CancellationToken cancellationToken)
                {
                        ShipMethod record = await this.ShipMethodRepository.GetName(model.Name);

                        if (record == null || record.ShipMethodID == this.existingRecordId)
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
    <Hash>04bab66af2d87c43d12bacf57e673789</Hash>
</Codenesium>*/