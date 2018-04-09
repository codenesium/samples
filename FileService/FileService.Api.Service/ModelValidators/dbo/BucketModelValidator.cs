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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>277a93d01323ae264e061b2565973182</Hash>
</Codenesium>*/