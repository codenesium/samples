using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	public class FileTypeModelValidator: AbstractFileTypeModelValidator, IFileTypeModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4c97186546d7fc076f54da15f38cf5c1</Hash>
</Codenesium>*/