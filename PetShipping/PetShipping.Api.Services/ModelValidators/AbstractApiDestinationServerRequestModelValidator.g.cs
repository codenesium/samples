using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiDestinationServerRequestModelValidator : AbstractValidator<ApiDestinationServerRequestModel>
	{
		private int existingRecordId;

		private IDestinationRepository destinationRepository;

		public AbstractApiDestinationServerRequestModelValidator(IDestinationRepository destinationRepository)
		{
			this.destinationRepository = destinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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
    <Hash>aadd7fa8680c81d2cdc7fd62647585c0</Hash>
</Codenesium>*/