using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractClaspModelValidator: AbstractValidator<ClaspModel>
	{
		public new ValidationResult Validate(ClaspModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ClaspModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainRepository ChainRepository { get; set; }
		public virtual void NextChainIdRules()
		{
			this.RuleFor(x => x.NextChainId).NotNull();
			this.RuleFor(x => x.NextChainId).Must(this.BeValidChain).When(x => x ?.NextChainId != null).WithMessage("Invalid reference");
		}

		public virtual void PreviousChainIdRules()
		{
			this.RuleFor(x => x.PreviousChainId).NotNull();
			this.RuleFor(x => x.PreviousChainId).Must(this.BeValidChain).When(x => x ?.PreviousChainId != null).WithMessage("Invalid reference");
		}

		private bool BeValidChain(int id)
		{
			return this.ChainRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>073a6f04dc817c0f346f6068ec58a07a</Hash>
</Codenesium>*/