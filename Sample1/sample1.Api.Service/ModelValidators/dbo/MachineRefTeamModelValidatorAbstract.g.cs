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
	public class MachineRefTeamModelValidatorAbstract: AbstractValidator<MachineRefTeamModel>
	{
		public MachineRepository MachineRepository {get; set;}

		public TeamRepository TeamRepository {get; set;}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void MachineIdRules()
		{
			RuleFor(x => x.MachineId).NotNull();
			RuleFor(x => x.MachineId).Must(BeValidMachine).When(x => x != null && x.MachineId != null).WithMessage("Invalid reference");
		}

		public virtual void TeamIdRules()
		{
			RuleFor(x => x.TeamId).NotNull();
			RuleFor(x => x.TeamId).Must(BeValidTeam).When(x => x != null && x.TeamId != null).WithMessage("Invalid reference");
		}

		public bool BeValidMachine(int id)
		{
			Response response = new Response();

			this.MachineRepository.GetById(id,response);
			return response.Machines.Count > 0;
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
    <Hash>421fa0f50ee48712e0b95e454edeef37</Hash>
</Codenesium>*/