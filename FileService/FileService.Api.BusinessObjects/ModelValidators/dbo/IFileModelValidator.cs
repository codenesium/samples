using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IFileModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(FileModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, FileModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4f717f535e8b826083dbb705c6af0404</Hash>
</Codenesium>*/