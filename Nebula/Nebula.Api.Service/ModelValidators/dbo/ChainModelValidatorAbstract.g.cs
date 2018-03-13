using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class ChainModelValidatorAbstract: AbstractValidator<ChainModel>
	{
		public ChainStatusRepository ChainStatusRepository {get; set;}

		public TeamRepository TeamRepository {get; set;}

		public virtual void ChainStatusIdRules()
		{
			RuleFor(x => x.ChainStatusId).NotNull();
			RuleFor(x => x.ChainStatusId).Must(BeValidChainStatus).When(x => x != null && x.ChainStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void TeamIdRules()
		{
			RuleFor(x => x.TeamId).NotNull();
			RuleFor(x => x.TeamId).Must(BeValidTeam).When(x => x != null && x.TeamId != null).WithMessage("Invalid reference");
		}

		public bool BeValidChainStatus(int id)
		{
			Response response = new Response();

			this.ChainStatusRepository.GetById(id,response);
			return response.ChainStatus.Count > 0;
		}

		public bool BeValidTeam(int id)
		{
			Response response = new Response();

			this.TeamRepository.GetById(id,response);
			return response.Teams.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>19538f4a2f099010257d81d5c2f63c31</Hash>
</Codenesium>*/