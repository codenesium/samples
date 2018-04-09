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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4c972e3bef018936c33ea46b67a2d850</Hash>
</Codenesium>*/