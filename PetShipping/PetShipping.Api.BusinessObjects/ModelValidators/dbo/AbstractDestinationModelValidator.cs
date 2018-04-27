using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractDestinationModelValidator: AbstractValidator<DestinationModel>
	{
		public new ValidationResult Validate(DestinationModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(DestinationModel model)
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
			return this.CountryRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>e7da891755d26da724ba366883924de2</Hash>
</Codenesium>*/