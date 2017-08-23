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
	public class ChainModelValidator: ChainModelValidatorAbstract
	{
		public ChainModelValidator()
		{   }

		public void CreateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void UpdateMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}

		public void PatchMode()
		{
			this.ChainStatusIdRules();
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
			this.TeamIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>e21311bad6e5a294c8ec9750477a4867</Hash>
</Codenesium>*/