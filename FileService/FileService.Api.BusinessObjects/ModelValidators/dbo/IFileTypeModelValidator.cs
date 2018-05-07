using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IFileTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(FileTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, FileTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fdd69e6585ac8522c25d3500b8f59769</Hash>
</Codenesium>*/