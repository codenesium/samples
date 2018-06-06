using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services

{
	public abstract class AbstractApiClaspRequestModelValidator: AbstractValidator<ApiClaspRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiClaspRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiClaspRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>3904dbffcdddae53eab98d40c2d3973e</Hash>
</Codenesium>*/