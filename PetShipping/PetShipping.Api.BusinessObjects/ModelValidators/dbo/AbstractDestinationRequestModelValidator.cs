using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiDestinationRequestModelValidator: AbstractValidator<ApiDestinationRequestModel>
	{
		public new ValidationResult Validate(ApiDestinationRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationRequestModel model)
		{
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
    <Hash>7cc1f7cff85bc5dc4aa3204344236e30</Hash>
</Codenesium>*/