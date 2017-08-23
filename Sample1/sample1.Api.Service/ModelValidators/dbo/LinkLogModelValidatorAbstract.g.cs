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
	public class LinkLogModelValidatorAbstract: AbstractValidator<LinkLogModel>
	{
		public LinkRepository LinkRepository {get; set;}

		public virtual void DateEnteredRules()
		{
			RuleFor(x => x.DateEntered).NotNull();
		}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void LinkIdRules()
		{
			RuleFor(x => x.LinkId).NotNull();
			RuleFor(x => x.LinkId).Must(BeValidLink).When(x => x != null && x.LinkId != null).WithMessage("Invalid reference");
		}

		public virtual void LogRules()
		{
			RuleFor(x => x.Log).NotNull();
			RuleFor(x => x.Log).Length(0,2147483647);
		}

		public bool BeValidLink(int id)
		{
			Response response = new Response();

			this.LinkRepository.GetById(id,response);
			return response.Links.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>32cae0e79b946b653137035dde6b9757</Hash>
</Codenesium>*/