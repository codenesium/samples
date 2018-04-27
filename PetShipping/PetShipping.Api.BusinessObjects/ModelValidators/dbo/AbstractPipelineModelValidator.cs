using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractPipelineModelValidator: AbstractValidator<PipelineModel>
	{
		public new ValidationResult Validate(PipelineModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PipelineModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IPipelineStatusRepository PipelineStatusRepository { get; set; }
		public virtual void PipelineStatusIdRules()
		{
			this.RuleFor(x => x.PipelineStatusId).NotNull();
			this.RuleFor(x => x.PipelineStatusId).Must(this.BeValidPipelineStatus).When(x => x ?.PipelineStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void SaleIdRules()
		{
			this.RuleFor(x => x.SaleId).NotNull();
		}

		private bool BeValidPipelineStatus(int id)
		{
			return this.PipelineStatusRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>230493d125256ef8d4a44c02d20484ad</Hash>
</Codenesium>*/