using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class LinkModelValidatorAbstract: AbstractValidator<LinkModel>
	{
		public MachineRepository MachineRepository {get; set;}

		public ChainRepository ChainRepository {get; set;}

		public LinkStatusRepository LinkStatusRepository {get; set;}

		public virtual void AssignedMachineIdRules()
		{
			RuleFor(x => x.AssignedMachineId).Must(BeValidMachine).When(x => x != null && x.AssignedMachineId != null).WithMessage("Invalid reference");
		}

		public virtual void ChainIdRules()
		{
			RuleFor(x => x.ChainId).NotNull();
			RuleFor(x => x.ChainId).Must(BeValidChain).When(x => x != null && x.ChainId != null).WithMessage("Invalid reference");
		}

		public virtual void DateCompletedRules()
		{}

		public virtual void DateStartedRules()
		{}

		public virtual void DynamicParametersRules()
		{
			RuleFor(x => x.DynamicParameters).Length(0,2147483647);
		}

		public virtual void ExternalIdRules()
		{
			RuleFor(x => x.ExternalId).NotNull();
		}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void LinkStatusIdRules()
		{
			RuleFor(x => x.LinkStatusId).NotNull();
			RuleFor(x => x.LinkStatusId).Must(BeValidLinkStatus).When(x => x != null && x.LinkStatusId != null).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void OrderRules()
		{
			RuleFor(x => x.Order).NotNull();
		}

		public virtual void ResponseRules()
		{
			RuleFor(x => x.Response).Length(0,2147483647);
		}

		public virtual void StaticParametersRules()
		{
			RuleFor(x => x.StaticParameters).Length(0,2147483647);
		}

		public bool BeValidMachine(Nullable<int> id)
		{
			Response response = new Response();

			this.MachineRepository.GetById(id.GetValueOrDefault(),response);
			return response.Machines.Count > 0;
		}

		public bool BeValidChain(int id)
		{
			Response response = new Response();

			this.ChainRepository.GetById(id,response);
			return response.Chains.Count > 0;
		}

		public bool BeValidLinkStatus(int id)
		{
			Response response = new Response();

			this.LinkStatusRepository.GetById(id,response);
			return response.LinkStatus.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>21727019865228f2ba99ed02993c45c1</Hash>
</Codenesium>*/