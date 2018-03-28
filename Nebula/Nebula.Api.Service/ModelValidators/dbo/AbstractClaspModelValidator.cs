using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service

{
	public abstract class AbstractClaspModelValidator: AbstractValidator<ClaspModel>
	{
		public new ValidationResult Validate(ClaspModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ClaspModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IChainRepository ChainRepository {get; set;}
		public virtual void PreviousChainIdRules()
		{
			RuleFor(x => x.PreviousChainId).NotNull();
			RuleFor(x => x.PreviousChainId).Must(BeValidChain).When(x => x ?.PreviousChainId != null).WithMessage("Invalid reference");
		}

		public virtual void NextChainIdRules()
		{
			RuleFor(x => x.NextChainId).NotNull();
			RuleFor(x => x.NextChainId).Must(BeValidChain).When(x => x ?.NextChainId != null).WithMessage("Invalid reference");
		}

		public bool BeValidChain(int id)
		{
			Response response = new Response();

			this.ChainRepository.GetById(id,response);
			return response.Chains.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>5eabef2d4fb4441a4a13b9610f8b55e5</Hash>
</Codenesium>*/