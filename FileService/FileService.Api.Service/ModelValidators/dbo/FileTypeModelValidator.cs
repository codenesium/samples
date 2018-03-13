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
			this.IdRules();
			this.NameRules();
		}

		public void UpdateMode()
		{
			this.IdRules();
			this.NameRules();
		}

		public void PatchMode()
		{
			this.IdRules();
			this.NameRules();
		}
	}
}

/*<Codenesium>
    <Hash>5061d7fb917d3bbce3ef45d0c4764df8</Hash>
</Codenesium>*/