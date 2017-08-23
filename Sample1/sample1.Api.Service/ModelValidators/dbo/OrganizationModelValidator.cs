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
	public class OrganizationModelValidator: OrganizationModelValidatorAbstract
	{
		public OrganizationModelValidator()
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
    <Hash>78027cfbbbfc45d417191aa61e294b19</Hash>
</Codenesium>*/