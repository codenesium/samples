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
    <Hash>1a50fb48fafc9bfd3cf437e752670826</Hash>
</Codenesium>*/