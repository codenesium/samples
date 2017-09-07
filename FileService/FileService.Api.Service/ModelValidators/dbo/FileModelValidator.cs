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
	public class FileModelValidator: FileModelValidatorAbstract
	{
		public FileModelValidator()
		{   }

		public void CreateMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}

		public void UpdateMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}

		public void PatchMode()
		{
			this.BucketIdRules();
			this.DateCreatedRules();
			this.DescriptionRules();
			this.ExpirationRules();
			this.ExtensionRules();
			this.ExternalIdRules();
			this.FileSizeInBytesRules();
			this.FileTypeIdRules();
			this.IdRules();
			this.LocationRules();
			this.PrivateKeyRules();
			this.PublicKeyRules();
		}
	}
}

/*<Codenesium>
    <Hash>135131f241c579e06c7983f33c5a11bc</Hash>
</Codenesium>*/