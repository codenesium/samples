using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiDestinationRequestModelValidator: AbstractValidator<ApiDestinationRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiDestinationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ICountryRepository CountryRepository { get; set; }
		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).NotNull();
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrderRules()
		{
			this.RuleFor(x => x.Order).NotNull();
		}

		private async Task<bool> BeValidCountry(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CountryRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1f5902f3e6c4de6fedfbfcf1269a6607</Hash>
</Codenesium>*/