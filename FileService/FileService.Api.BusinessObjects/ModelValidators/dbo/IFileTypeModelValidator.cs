using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IFileTypeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(FileTypeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, FileTypeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>40d87298e3f84dffc913e230630829dc</Hash>
</Codenesium>*/