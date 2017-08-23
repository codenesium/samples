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
    <Hash>cc56307eaf8466f51511abf4b4fb7251</Hash>
</Codenesium>*/