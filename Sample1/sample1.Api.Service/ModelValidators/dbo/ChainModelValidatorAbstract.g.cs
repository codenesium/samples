using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;

namespace sample1NS.Api.Service

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
    <Hash>afae17a715a12f5f82e3ced8d375a0b2</Hash>
</Codenesium>*/