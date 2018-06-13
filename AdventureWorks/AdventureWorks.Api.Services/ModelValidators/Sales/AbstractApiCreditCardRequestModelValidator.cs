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
        public abstract class AbstractApiCreditCardRequestModelValidator: AbstractValidator<ApiCreditCardRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiCreditCardRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCreditCardRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICreditCardRepository CreditCardRepository { get; set; }
                public virtual void CardNumberRules()
                {
                        this.RuleFor(x => x.CardNumber).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetCardNumber).When(x => x ?.CardNumber != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCreditCardRequestModel.CardNumber));
                        this.RuleFor(x => x.CardNumber).Length(0, 25);
                }

                public virtual void CardTypeRules()
                {
                        this.RuleFor(x => x.CardType).NotNull();
                        this.RuleFor(x => x.CardType).Length(0, 50);
                }

                public virtual void ExpMonthRules()
                {
                }

                public virtual void ExpYearRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                private async Task<bool> BeUniqueGetCardNumber(ApiCreditCardRequestModel model,  CancellationToken cancellationToken)
                {
                        CreditCard record = await this.CreditCardRepository.GetCardNumber(model.CardNumber);

                        if (record == null || (this.existingRecordId != default (int) && record.CreditCardID == this.existingRecordId))
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
    <Hash>cd3476d139cb048acb397a659d310683</Hash>
</Codenesium>*/