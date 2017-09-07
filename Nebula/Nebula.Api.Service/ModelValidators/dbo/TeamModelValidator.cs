using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Service
{
	public class TeamModelValidator: TeamModelValidatorAbstract
	{
		public TeamModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
			this.OrganizationIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>01adac7ad213e44f248f730f936c2ad3</Hash>
</Codenesium>*/