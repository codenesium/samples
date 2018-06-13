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
        public abstract class AbstractApiVendorRequestModelValidator: AbstractValidator<ApiVendorRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiVendorRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiVendorRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IVendorRepository VendorRepository { get; set; }
                public virtual void AccountNumberRules()
                {
                        this.RuleFor(x => x.AccountNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetAccountNumber).When(x => x ?.AccountNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiVendorRequestModel.AccountNumber));
                        this.RuleFor(x => x.AccountNumber).Length(0, 15);
                }

                public virtual void ActiveFlagRules()
                {
                }

                public virtual void CreditRatingRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void PreferredVendorStatusRules()
                {
                }

                public virtual void PurchasingWebServiceURLRules()
                {
                        this.RuleFor(x => x.PurchasingWebServiceURL).Length(0, 1024);
                }

                private async Task<bool> BeUniqueGetAccountNumber(ApiVendorRequestModel model,  CancellationToken cancellationToken)
                {
                        Vendor record = await this.VendorRepository.GetAccountNumber(model.AccountNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.BusinessEntityID == this.existingRecordId))
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
    <Hash>c901a8d89b94880c626abb8cbf163dda</Hash>
</Codenesium>*/