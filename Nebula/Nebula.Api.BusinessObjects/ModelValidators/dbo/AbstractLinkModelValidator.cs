using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects

{
	public abstract class AbstractApiLinkModelValidator: AbstractValidator<ApiLinkModel>
	{
		public new ValidationResult Validate(ApiLinkModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IMachineRepository MachineRepository { get; set; }
		public IChainRepository ChainRepository { get; set; }
		public ILinkStatusRepository LinkStatusRepository { get; set; }
		public virtual void AssignedMachineIdRules()
		{
			this.RuleFor(x => x.AssignedMachineId).Must(this.BeValidMachine).When(x => x ?.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainIdRules()
		{
			this.RuleFor(x => x.ChainId).NotNull();
			this.RuleFor(x => x.ChainId).Must(this.BeValidChain).When(x => x ?.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCompletedRules()
		{                       }

		public virtual void DateStartedRules()
		{                       }

		public virtual void DynamicParametersRules()
		{
			this.RuleFor(x => x.DynamicParameters).Length(0, 2147483647);
		}

		public virtual void ExternalIdRules()
		{
			this.RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void LinkStatusIdRules()
		{
			this.RuleFor(x => x.LinkStatusId).NotNull();
			this.RuleFor(x => x.LinkStatusId).Must(this.BeValidLinkStatus).When(x => x ?.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void OrderRules()
		{
			this.RuleFor(x => x.Order).NotNull();
		}

		public virtual void ResponseRules()
		{
			this.RuleFor(x => x.Response).Length(0, 2147483647);
		}

		public virtual void StaticParametersRules()
		{
			this.RuleFor(x => x.StaticParameters).Length(0, 2147483647);
		}

		public virtual void TimeoutInSecondsRules()
		{
			this.RuleFor(x => x.TimeoutInSeconds).NotNull();
		}

		private bool BeValidMachine(Nullable<int> id)
		{
			return this.MachineRepository.Get(id.GetValueOrDefault()) != null;
		}

		private bool BeValidChain(int id)
		{
			return this.ChainRepository.Get(id) != null;
		}

		private bool BeValidLinkStatus(int id)
		{
			return this.LinkStatusRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>24368c9018ed20ca7aa7c4fab1020388</Hash>
</Codenesium>*/