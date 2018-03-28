using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractMachineRefTeamModelValidator: AbstractValidator<MachineRefTeamModel>
	{
		public new ValidationResult Validate(MachineRefTeamModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(MachineRefTeamModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IMachineRepository MachineRepository {get; set;}
		public ITeamRepository TeamRepository {get; set;}
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
    <Hash>6e394b8149dac9c29e40d1be1918ba99</Hash>
</Codenesium>*/