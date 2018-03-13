using FluentValidation;
using System;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service

{
	public class TeamModelValidatorAbstract: AbstractValidator<TeamModel>
	{
		public OrganizationRepository OrganizationRepository {get; set;}

		public virtual void IdRules()
		{
			RuleFor(x => x.Id).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,128);
		}

		public virtual void OrganizationIdRules()
		{
			RuleFor(x => x.OrganizationId).NotNull();
			RuleFor(x => x.OrganizationId).Must(BeValidOrganization).When(x => x != null && x.OrganizationId != null).WithMessage("Invalid reference");
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
    <Hash>6f8a98833ad0dcb571bf13faee38f82b</Hash>
</Codenesium>*/