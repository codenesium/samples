using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiDestinationRequestModelValidator : AbstractValidator<ApiDestinationRequestModel>
	{
		private int existingRecordId;

		private IDestinationRepository destinationRepository;

		public AbstractApiDestinationRequestModelValidator(IDestinationRepository destinationRepository)
		{
			this.destinationRepository = destinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => x?.CountryId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrderRules()
		{
		}

		private async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.destinationRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>8c688e8b4905aa375456391d8d1c935f</Hash>
</Codenesium>*/