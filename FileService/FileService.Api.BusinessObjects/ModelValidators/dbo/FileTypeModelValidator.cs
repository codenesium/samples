using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class FileTypeModelValidator: AbstractFileTypeModelValidator, IFileTypeModelValidator
	{
		public FileTypeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(FileTypeModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, FileTypeModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c443f09a6dbce2071b7698160c107d07</Hash>
</Codenesium>*/