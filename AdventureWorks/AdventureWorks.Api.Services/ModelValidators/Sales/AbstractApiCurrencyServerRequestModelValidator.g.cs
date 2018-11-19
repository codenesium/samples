using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCurrencyServerRequestModelValidator : AbstractValidator<ApiCurrencyServerRequestModel>
	{
		private string existingRecordId;

		private ICurrencyRepository currencyRepository;

		public AbstractApiCurrencyServerRequestModelValidator(ICurrencyRepository currencyRepository)
		{
			this.currencyRepository = currencyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCurrencyServerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiCurrencyServerRequestModel model,  CancellationToken cancellationToken)
		{
			Currency record = await this.currencyRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.CurrencyCode == this.existingRecordId))
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
    <Hash>5f5dca9a4411dc6e6a426a1bc8a749e5</Hash>
</Codenesium>*/