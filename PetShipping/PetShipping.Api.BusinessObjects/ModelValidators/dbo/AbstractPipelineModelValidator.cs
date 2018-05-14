using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects

{
	public abstract class AbstractApiPipelineModelValidator: AbstractValidator<ApiPipelineModel>
	{
		public new ValidationResult Validate(ApiPipelineModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPipelineModel model)
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
			return this.PipelineStatusRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>751e49157b9bfcdbb3afef38f591f4a5</Hash>
</Codenesium>*/