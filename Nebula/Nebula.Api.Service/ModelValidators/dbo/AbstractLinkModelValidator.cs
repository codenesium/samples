using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractLinkModelValidator: AbstractValidator<LinkModel>
	{
		public new ValidationResult Validate(LinkModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(LinkModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainRepository ChainRepository { get; set; }
		public IMachineRepository MachineRepository { get; set; }
		public ILinkStatusRepository LinkStatusRepository { get; set; }
		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void DynamicParametersRules()
		{
			this.RuleFor(x => x.DynamicParameters).Length(0, 2147483647);
		}

		public virtual void StaticParametersRules()
		{
			this.RuleFor(x => x.StaticParameters).Length(0, 2147483647);
		}

		public virtual void ChainIdRules()
		{
			this.RuleFor(x => x.ChainId).NotNull();
			this.RuleFor(x => x.ChainId).Must(this.BeValidChain).When(x => x ?.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void AssignedMachineIdRules()
		{
			this.RuleFor(x => x.AssignedMachineId).Must(this.BeValidMachine).When(x => x ?.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).NotNull();
			this.RuleFor(x => x.LinkStatusId).Must(this.BeValidLinkStatus).When(x => x ?.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void OrderRules()
		{
			this.RuleFor(x => x.Order).NotNull();
		}

		public virtual void DateStartedRules()
		{                       }

		public virtual void DateCompletedRules()
		{                       }

		public virtual void ResponseRules()
		{
			this.RuleFor(x => x.Response).Length(0, 2147483647);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}

		private bool BeValidChain(int id)
		{
			return this.ChainRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidMachine(Nullable<int> id)
		{
			return this.MachineRepository.GetByIdDirect(id.GetValueOrDefault()) != null;
		}

		private bool BeValidLinkStatus(int id)
		{
			return this.LinkStatusRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>052a6b74eed1b06833bee3adcb632ba2</Hash>
</Codenesium>*/