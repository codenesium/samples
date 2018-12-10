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

		protected IAirlineRepository AirlineRepository { get; private set; }

		public AbstractApiAirlineServerRequestModelValidator(IAirlineRepository airlineRepository)
		{
			this.AirlineRepository = airlineRepository;
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
    <Hash>2eb23d448780b886132fbd1d541a68f3</Hash>
</Codenesium>*/