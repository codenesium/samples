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
    <Hash>5db42445cb47d35527320aa6245b0d1e</Hash>
</Codenesium>*/