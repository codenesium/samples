using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public class BucketModelValidator: AbstractBucketModelValidator,IBucketModelValidator
	{
		public BucketModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ExternalIdRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ExternalIdRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.ExternalIdRules();
		}
	}
}

/*<Codenesium>
    <Hash>35f60bf844267cbe7ac630f3b2b92642</Hash>
</Codenesium>*/