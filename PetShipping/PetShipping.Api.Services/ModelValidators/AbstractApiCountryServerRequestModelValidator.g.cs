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
	public abstract class AbstractApiCountryServerRequestModelValidator : AbstractValidator<ApiCountryServerRequestModel>
	{
		private int existingRecordId;

		private ICountryRepository countryRepository;

		public AbstractApiCountryServerRequestModelValidator(ICountryRepository countryRepository)
		{
			this.countryRepository = countryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCountryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>8d98776bfc5404f419f5b5e5453d8c89</Hash>
</Codenesium>*/