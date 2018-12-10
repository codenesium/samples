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
	public abstract class AbstractApiDestinationServerRequestModelValidator : AbstractValidator<ApiDestinationServerRequestModel>
	{
		private int existingRecordId;

		protected IDestinationRepository DestinationRepository { get; private set; }

		public AbstractApiDestinationServerRequestModelValidator(IDestinationRepository destinationRepository)
		{
			this.DestinationRepository = destinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void OrderRules()
		{
		}

		protected async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.DestinationRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>e213f1478db21ed74c73e7b5aaf23a68</Hash>
</Codenesium>*/