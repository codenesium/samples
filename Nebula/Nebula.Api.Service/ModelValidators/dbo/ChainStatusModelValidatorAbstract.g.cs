using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class ChainStatusModelValidatorAbstract: AbstractValidator<ChainStatusModel>
	{
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>80e8613330c6af4809ce42a09e5fc65d</Hash>
</Codenesium>*/