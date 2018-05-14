using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiAirTransportModelValidator: AbstractValidator<ApiAirTransportModel>
	{
		public new ValidationResult Validate(ApiAirTransportModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAirTransportModel model)
		{
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
			this.RuleFor(x => x.HandlerId).Must(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
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

		private bool BeValidHandler(int id)
		{
			return this.HandlerRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>fc4cba71f20d163e37d3b86dc6fd1dfe</Hash>
</Codenesium>*/