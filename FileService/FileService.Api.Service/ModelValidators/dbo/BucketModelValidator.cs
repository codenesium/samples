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
    <Hash>933d98e0a8dc8fa100d3ab21191feb3f</Hash>
</Codenesium>*/