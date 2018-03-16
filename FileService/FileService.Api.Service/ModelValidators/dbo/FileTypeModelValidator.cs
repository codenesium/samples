using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class FileTypeModelValidator: FileTypeModelValidatorAbstract
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
    <Hash>cdc3734e30c6a16bff4db6693a7420e7</Hash>
</Codenesium>*/