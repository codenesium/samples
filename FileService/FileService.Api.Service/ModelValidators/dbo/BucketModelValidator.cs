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
    <Hash>66f63eda84a9a92d69fac9ca436e22bc</Hash>
</Codenesium>*/