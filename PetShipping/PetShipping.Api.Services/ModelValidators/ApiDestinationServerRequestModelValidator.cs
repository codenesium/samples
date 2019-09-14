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
	public class ApiDestinationServerRequestModelValidator : AbstractValidator<ApiDestinationServerRequestModel>, IApiDestinationServerRequestModelValidator
	{
		private int existingRecordId;

		protected IDestinationRepository DestinationRepository { get; private set; }

		public ApiDestinationServerRequestModelValidator(IDestinationRepository destinationRepository)
		{
			this.DestinationRepository = destinationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiDestinationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationServerRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationServerRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>85e1902c5c07f570320a1dae219d1c19</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/