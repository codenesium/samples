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
        public abstract class AbstractApiAddressTypeRequestModelValidator : AbstractValidator<ApiAddressTypeRequestModel>
        {
                private int existingRecordId;

                private IAddressTypeRepository addressTypeRepository;

                public AbstractApiAddressTypeRequestModelValidator(IAddressTypeRepository addressTypeRepository)
                {
                        this.addressTypeRepository = addressTypeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiAddressTypeRequestModel model, int id)
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiAddressTypeRequestModel model,  CancellationToken cancellationToken)
                {
                        AddressType record = await this.addressTypeRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default(int) && record.AddressTypeID == this.existingRecordId))
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
    <Hash>1e93a1cdc819a32a63abd6412e2d8e7a</Hash>
</Codenesium>*/