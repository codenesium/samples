using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class TeamModelValidatorAbstract: AbstractValidator<TeamModel>
	{
		public OrganizationRepository OrganizationRepository {get; set;}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void OrganizationIdRules()
		{
			RuleFor(x => x.OrganizationId).NotNull();
			RuleFor(x => x.OrganizationId).Must(BeValidOrganization).When(x => x ?.OrganizationId != null).WithMessage("Invalid reference");
		}

		public bool BeValidOrganization(int id)
		{
			Response response = new Response();

			this.OrganizationRepository.GetById(id,response);
			return response.Organizations.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>9a555a20b7623cf8e4906b9213bd9cf7</Hash>
</Codenesium>*/