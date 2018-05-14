using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiDestinationModelValidator: AbstractValidator<ApiDestinationModel>
	{
		public new ValidationResult Validate(ApiDestinationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ICountryRepository CountryRepository { get; set; }
		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).NotNull();
			this.RuleFor(x => x.CountryId).Must(this.BeValidCountry).When(x => x ?.CountryId != null).WithMessage("Invalid reference");
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

		private bool BeValidCountry(int id)
		{
			return this.CountryRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>a6ee7a01c903a537f4fc1ef19695d497</Hash>
</Codenesium>*/