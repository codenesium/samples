using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiOtherTransportModelValidator: AbstractValidator<ApiOtherTransportModel>
	{
		public new ValidationResult Validate(ApiOtherTransportModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiOtherTransportModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IHandlerRepository HandlerRepository { get; set; }
		public IPipelineStepRepository PipelineStepRepository { get; set; }
		public virtual void HandlerIdRules()
		{
			this.RuleFor(x => x.HandlerId).NotNull();
			this.RuleFor(x => x.HandlerId).Must(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
		}

		public virtual void PipelineStepIdRules()
		{
			this.RuleFor(x => x.PipelineStepId).NotNull();
			this.RuleFor(x => x.PipelineStepId).Must(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
		}

		private bool BeValidHandler(int id)
		{
			return this.HandlerRepository.Get(id) != null;
		}

		private bool BeValidPipelineStep(int id)
		{
			return this.PipelineStepRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>12780fbf1dd5f05ae974f787bdfc000c</Hash>
</Codenesium>*/