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

		public ITeamRepository TeamRepository {get; set;}
		public IChainStatusRepository ChainStatusRepository {get; set;}
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void TeamIdRules()
		{
			RuleFor(x => x.TeamId).NotNull();
			RuleFor(x => x.TeamId).Must(BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainStatusIdRules()
		{
			RuleFor(x => x.ChainStatusId).NotNull();
			RuleFor(x => x.ChainStatusId).Must(BeValidChainStatus).When(x => x ?.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public bool BeValidTeam(int id)
		{
			Response response = new Response();

			this.TeamRepository.GetById(id,response);
			return response.Teams.Count > 0;
		}

		public bool BeValidChainStatus(int id)
		{
			Response response = new Response();

			this.ChainStatusRepository.GetById(id,response);
			return response.ChainStatus.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>098c412ee4c75b716593d8fc55660287</Hash>
</Codenesium>*/