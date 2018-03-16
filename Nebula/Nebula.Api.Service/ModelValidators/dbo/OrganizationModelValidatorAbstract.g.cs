using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class OrganizationModelValidatorAbstract: AbstractValidator<OrganizationModel>
	{
		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}
	}
}

/*<Codenesium>
    <Hash>cb53b9d5dfde2b80d601c840d548e5fb</Hash>
</Codenesium>*/