using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiClaspRequestModelValidator: AbstractValidator<ApiClaspRequestModel>
	{
		public new ValidationResult Validate(ApiClaspRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiClaspRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainRepository ChainRepository { get; set; }
		public virtual void NextChainIdRules()
		{
			this.RuleFor(x => x.NextChainId).NotNull();
			this.RuleFor(x => x.NextChainId).MustAsync(this.BeValidChain).When(x => x ?.NextChainId != null).WithMessage("Invalid reference");
		}

		public virtual void PreviousChainIdRules()
		{
			this.RuleFor(x => x.PreviousChainId).NotNull();
			this.RuleFor(x => x.PreviousChainId).MustAsync(this.BeValidChain).When(x => x ?.PreviousChainId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidChain(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ChainRepository.Get(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c98f26aff717ce3d54b4028e1a2702c7</Hash>
</Codenesium>*/