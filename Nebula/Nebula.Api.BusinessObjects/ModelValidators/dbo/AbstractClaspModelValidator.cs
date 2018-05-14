using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiClaspModelValidator: AbstractValidator<ApiClaspModel>
	{
		public new ValidationResult Validate(ApiClaspModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiClaspModel model)
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
    <Hash>6a07395ec1f78a11ac54a0726b32168a</Hash>
</Codenesium>*/