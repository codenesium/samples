using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

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
    <Hash>6a6b529566449d1f28dc105b65e61080</Hash>
</Codenesium>*/