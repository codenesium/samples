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
    <Hash>cd43cce52c371d2523ac04fc1249f9ae</Hash>
</Codenesium>*/