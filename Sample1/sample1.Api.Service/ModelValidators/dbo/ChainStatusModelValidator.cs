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
	public class ChainStatusModelValidator: ChainStatusModelValidatorAbstract
	{
		public ChainStatusModelValidator()
		{   }

		public void CreateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>1d5a83e8af02262d65635d94c30279f0</Hash>
</Codenesium>*/