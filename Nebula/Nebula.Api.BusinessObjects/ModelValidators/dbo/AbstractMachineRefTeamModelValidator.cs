using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiMachineRefTeamModelValidator: AbstractValidator<ApiMachineRefTeamModel>
	{
		public new ValidationResult Validate(ApiMachineRefTeamModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiMachineRefTeamModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IMachineRepository MachineRepository { get; set; }
		public ITeamRepository TeamRepository { get; set; }
		public virtual void MachineIdRules()
		{
			this.RuleFor(x => x.MachineId).NotNull();
			this.RuleFor(x => x.MachineId).Must(this.BeValidMachine).When(x => x ?.MachineId != null).WithMessage("Invalid reference");
		}

		public virtual void TeamIdRules()
		{
			this.RuleFor(x => x.TeamId).NotNull();
			this.RuleFor(x => x.TeamId).Must(this.BeValidTeam).When(x => x ?.TeamId != null).WithMessage("Invalid reference");
		}

		private bool BeValidMachine(int id)
		{
			return this.MachineRepository.Get(id) != null;
		}

		private bool BeValidTeam(int id)
		{
			return this.TeamRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>249ad4453d4faf22feb1b98a9d738725</Hash>
</Codenesium>*/