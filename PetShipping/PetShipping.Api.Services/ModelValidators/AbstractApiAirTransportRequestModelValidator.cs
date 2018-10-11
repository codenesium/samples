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
	public abstract class AbstractApiAirTransportRequestModelValidator : AbstractValidator<ApiAirTransportRequestModel>
	{
		private int existingRecordId;

		private IAirTransportRepository airTransportRepository;

		public AbstractApiAirTransportRequestModelValidator(IAirTransportRepository airTransportRepository)
		{
			this.airTransportRepository = airTransportRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirTransportRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void FlightNumberRules()
		{
			this.RuleFor(x => x.FlightNumber).NotNull();
			this.RuleFor(x => x.FlightNumber).Length(0, 12);
		}

		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandlerByHandlerId).When(x => x?.HandlerId != null).WithMessage("Invalid reference");
		}

		public virtual void IdRules()
		{
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

		private async Task<bool> BeValidHandlerByHandlerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.airTransportRepository.HandlerByHandlerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>0348aa279dc84ce368c04bec78bfa34f</Hash>
</Codenesium>*/