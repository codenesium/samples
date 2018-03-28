using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	public class FileTypeModelValidator: AbstractFileTypeModelValidator,IFileTypeModelValidator
	{
		public FileTypeModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
		}

		public void PatchMode()
		{
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>1bbc47439510d41dd2597cc21c075a31</Hash>
</Codenesium>*/