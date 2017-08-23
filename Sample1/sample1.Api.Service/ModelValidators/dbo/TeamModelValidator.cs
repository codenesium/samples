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
    <Hash>ffa2e95556cd72f7bd58c982cbde93a5</Hash>
</Codenesium>*/