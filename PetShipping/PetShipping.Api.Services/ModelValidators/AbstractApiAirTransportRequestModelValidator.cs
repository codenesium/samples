using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiAirTransportRequestModelValidator: AbstractValidator<ApiAirTransportRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiAirTransportRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirTransportRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IHandlerRepository HandlerRepository { get; set; }
		public virtual void FlightNumberRules()
		{
			this.RuleFor(x => x.FlightNumber).NotNull();
			this.RuleFor(x => x.FlightNumber).Length(0, 12);
		}

		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).NotNull();
			this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
		}

		public virtual void IdRules()
		{
			this.RuleFor(x => x.Id).NotNull();
		}

		public virtual void LandDateRules()
		{
			this.RuleFor(x => x.LandDate).NotNull();
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
		}

		public virtual void TakeoffDateRules()
		{
			this.RuleFor(x => x.TakeoffDate).NotNull();
		}

		private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
		{
			var record = await this.HandlerRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>55a40ebc68d2262bcfde5bae0d42376c</Hash>
</Codenesium>*/