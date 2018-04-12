using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class BucketModelValidator: AbstractBucketModelValidator, IBucketModelValidator
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
    <Hash>a6cea888904670932d0b95da150197a6</Hash>
</Codenesium>*/