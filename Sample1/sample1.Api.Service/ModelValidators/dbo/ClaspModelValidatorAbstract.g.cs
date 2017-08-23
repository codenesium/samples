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
	public class ClaspModelValidatorAbstract: AbstractValidator<ClaspModel>
	{
		public ChainRepository ChainRepository {get; set;}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void NextChainIdRules()
		{
			RuleFor(x => x.NextChainId).NotNull();
			RuleFor(x => x.NextChainId).Must(BeValidChain).When(x => x != null && x.NextChainId != null).WithMessage("Invalid reference");
		}

		public virtual void PreviousChainIdRules()
		{
			RuleFor(x => x.PreviousChainId).NotNull();
			RuleFor(x => x.PreviousChainId).Must(BeValidChain).When(x => x != null && x.PreviousChainId != null).WithMessage("Invalid reference");
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
    <Hash>72ad64b8ebe95abcd1ab721c687dfe95</Hash>
</Codenesium>*/