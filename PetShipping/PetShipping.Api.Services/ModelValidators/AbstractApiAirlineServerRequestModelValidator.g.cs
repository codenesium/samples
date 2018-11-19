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
	public abstract class AbstractApiAirlineServerRequestModelValidator : AbstractValidator<ApiAirlineServerRequestModel>
	{
		private int existingRecordId;

		private IAirlineRepository airlineRepository;

		public AbstractApiAirlineServerRequestModelValidator(IAirlineRepository airlineRepository)
		{
			this.airlineRepository = airlineRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirlineServerRequestModel model, int id)
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
    <Hash>5f3427d3b8908047e5ea328f57e7db1f</Hash>
</Codenesium>*/