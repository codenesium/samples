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
	public abstract class AbstractApiCountryRegionCurrencyRequestModelValidator: AbstractValidator<ApiCountryRegionCurrencyRequestModel>
	{
		private string existingRecordId;

		public new ValidationResult Validate(ApiCountryRegionCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryRegionCurrencyRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ICurrencyRepository CurrencyRepository { get; set; }
		public virtual void CurrencyCodeRules()
		{
			this.RuleFor(x => x.CurrencyCode).NotNull();
			this.RuleFor(x => x.CurrencyCode).MustAsync(this.BeValidCurrency).When(x => x ?.CurrencyCode != null).WithMessage("Invalid reference");
			this.RuleFor(x => x.CurrencyCode).Length(0, 3);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private async Task<bool> BeValidCurrency(string id,  CancellationToken cancellationToken)
		{
			var record = await this.CurrencyRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>d6d86e422a9011558d7ea2122285f9c4</Hash>
</Codenesium>*/