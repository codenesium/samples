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
	public abstract class AbstractApiChainRequestModelValidator: AbstractValidator<ApiChainRequestModel>
	{
		public new ValidationResult Validate(ApiChainRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiChainRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainStatusRepository ChainStatusRepository { get; set; }
		public ITeamRepository TeamRepository { get; set; }
		public IChainRepository ChainRepository { get; set; }
		public virtual void ChainStatusIdRules()
		{
			this.RuleFor(x => x.ChainStatusId).NotNull();
			this.RuleFor(x => x.ChainStatusId).MustAsync(this.BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetExternalId).When(x => x ?.ExternalId != null).WithMessage("Violates unique constraint").WithName(nameof(ApiChainRequestModel.ExternalId));
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).NotNull();
			this.RuleFor(x => x.TeamId).MustAsync(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidChainStatus(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ChainStatusRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeValidTeam(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TeamRepository.Get(id);

			return record != null;
		}

		private async Task<bool> BeUniqueGetExternalId(ApiChainRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ChainRepository.GetExternalId(model.ExternalId);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>36ec5cd8cbe24f2c4e03130a3d875601</Hash>
</Codenesium>*/