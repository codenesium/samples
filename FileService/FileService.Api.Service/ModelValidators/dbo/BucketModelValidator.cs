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
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.ExternalIdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.ExternalIdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>5d77138954f3bed747db6f5dcdacce07</Hash>
</Codenesium>*/