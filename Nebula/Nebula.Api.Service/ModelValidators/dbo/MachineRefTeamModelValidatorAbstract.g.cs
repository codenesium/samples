using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class MachineRefTeamModelValidatorAbstract: AbstractValidator<MachineRefTeamModel>
	{
		public MachineRepository MachineRepository {get; set;}

		public TeamRepository TeamRepository {get; set;}

		public virtual void MachineIdRules()
		{
			RuleFor(x => x.MachineId).NotNull();
			RuleFor(x => x.MachineId).Must(BeValidMachine).When(x => x ?.MachineId != null).WithMessage("Invalid reference");
		}

		public virtual void TeamIdRules()
		{
			RuleFor(x => x.TeamId).NotNull();
			RuleFor(x => x.TeamId).Must(BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
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
    <Hash>5c304b53f7883e7df36735d1a76c5efb</Hash>
</Codenesium>*/