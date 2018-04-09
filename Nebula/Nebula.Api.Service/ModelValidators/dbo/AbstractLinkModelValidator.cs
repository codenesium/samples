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

		public IChainRepository ChainRepository {get; set;}
		public IMachineRepository MachineRepository {get; set;}
		public ILinkStatusRepository LinkStatusRepository {get; set;}
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void DynamicParametersRules()
		{
			RuleFor(x => x.DynamicParameters).Length(0,2147483647);
		}

		public virtual void StaticParametersRules()
		{
			RuleFor(x => x.StaticParameters).Length(0,2147483647);
		}

		public virtual void ChainIdRules()
		{
			RuleFor(x => x.ChainId).NotNull();
			RuleFor(x => x.ChainId).Must(BeValidChain).When(x => x ?.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void AssignedMachineIdRules()
		{
			RuleFor(x => x.AssignedMachineId).Must(BeValidMachine).When(x => x ?.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void LinkStatusIdRules()
		{
			RuleFor(x => x.LinkStatusId).NotNull();
			RuleFor(x => x.LinkStatusId).Must(BeValidLinkStatus).When(x => x ?.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void OrderRules()
		{
			RuleFor(x => x.Order).NotNull();
		}

		public virtual void DateStartedRules()
		{                       }

		public virtual void DateCompletedRules()
		{                       }

		public virtual void ResponseRules()
		{
			RuleFor(x => x.Response).Length(0,2147483647);
		}

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
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
    <Hash>0ccaa1698cee3f2a465821172495a384</Hash>
</Codenesium>*/