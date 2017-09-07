using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class BucketModelValidator: BucketModelValidatorAbstract
	{
		public BucketModelValidator()
		{   }

		public void CreateMode()
		{
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.ExternalIdRules();
			this.IdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>4d7e35237fb34dbd822e1694606032d5</Hash>
</Codenesium>*/