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
	public class ApiAirTransportServerRequestModelValidator : AbstractValidator<ApiAirTransportServerRequestModel>, IApiAirTransportServerRequestModelValidator
	{
		private int existingRecordId;

		protected IAirTransportRepository AirTransportRepository { get; private set; }

		public ApiAirTransportServerRequestModelValidator(IAirTransportRepository airTransportRepository)
		{
			this.AirTransportRepository = airTransportRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirTransportServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirTransportServerRequestModel model)
		{
			this.AirlineIdRules();
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirTransportServerRequestModel model)
		{
			this.AirlineIdRules();
			this.FlightNumberRules();
			this.HandlerIdRules();
			this.LandDateRules();
			this.PipelineStepIdRules();
			this.TakeoffDateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void AirlineIdRules()
		{
		}

		public virtual void FlightNumberRules()
		{
			this.RuleFor(x => x.FlightNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FlightNumber).Length(0, 12).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandlerByHandlerId).When(x => !x?.HandlerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void LandDateRules()
		{
		}

		public virtual void PipelineStepIdRules()
		{
		}

		public virtual void TakeoffDateRules()
		{
		}

		protected async Task<bool> BeValidHandlerByHandlerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.AirTransportRepository.HandlerByHandlerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f4d8ec1e5fd2425dcb3a4808c2e1239f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/