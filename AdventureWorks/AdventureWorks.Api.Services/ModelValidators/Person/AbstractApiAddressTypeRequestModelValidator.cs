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
        public abstract class AbstractApiAddressTypeRequestModelValidator: AbstractValidator<ApiAddressTypeRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiAddressTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiAddressTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IAddressTypeRepository AddressTypeRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiAddressTypeRequestModel model,  CancellationToken cancellationToken)
                {
                        AddressType record = await this.AddressTypeRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.AddressTypeID == this.existingRecordId))
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
    <Hash>b8736083acc8bd37b96e312958b60d5f</Hash>
</Codenesium>*/