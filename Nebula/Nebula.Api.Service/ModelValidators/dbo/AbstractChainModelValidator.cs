using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractChainModelValidator: AbstractValidator<ChainModel>
	{
		public new ValidationResult Validate(ChainModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ChainModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ITeamRepository TeamRepository { get; set; }
		public IChainStatusRepository ChainStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).NotNull();
			this.RuleFor(x => x.TeamId).Must(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainStatusIdRules()
		{
			this.RuleFor(x => x.ChainStatusId).NotNull();
			this.RuleFor(x => x.ChainStatusId).Must(this.BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}

		private bool BeValidTeam(int id)
		{
			return this.TeamRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidChainStatus(int id)
		{
			return this.ChainStatusRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>f05db7c368a3996438fed672deaaec14</Hash>
</Codenesium>*/