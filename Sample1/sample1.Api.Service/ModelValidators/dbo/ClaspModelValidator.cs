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
	public class ClaspModelValidator: ClaspModelValidatorAbstract
	{
		public ClaspModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NextChainIdRules();
			this.PreviousChainIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>2dbb521492eb2e3e44e98bbcd4f95cba</Hash>
</Codenesium>*/