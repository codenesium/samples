using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IFileModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(FileModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, FileModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d9d0eb05098c6ef988d2fd37b1976416</Hash>
</Codenesium>*/