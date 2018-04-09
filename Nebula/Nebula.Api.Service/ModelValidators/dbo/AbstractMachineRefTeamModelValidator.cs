using Codenesium.DataConversionExtensions.AspNetCore;
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

		private bool BeValidMachine(int id)
		{
			return this.MachineRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidTeam(int id)
		{
			return this.TeamRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>c4d4cd326f53766f15deea9085fe953a</Hash>
</Codenesium>*/