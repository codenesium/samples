using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

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

		public IChainStatusRepository ChainStatusRepository { get; set; }
		public ITeamRepository TeamRepository { get; set; }
		public virtual void ChainStatusIdRules()
		{
			this.RuleFor(x => x.ChainStatusId).NotNull();
			this.RuleFor(x => x.ChainStatusId).Must(this.BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}

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

		private bool BeValidChainStatus(int id)
		{
			return this.ChainStatusRepository.Get(id) != null;
		}

		private bool BeValidTeam(int id)
		{
			return this.TeamRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>9cc946c0e3e99430474b369a82cacaf8</Hash>
</Codenesium>*/