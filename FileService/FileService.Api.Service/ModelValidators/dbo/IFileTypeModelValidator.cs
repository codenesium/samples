using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Service
{
	public interface IFileTypeModelValidator
	{
		ValidationResult Validate(FileTypeModel entity);

		Task<ValidationResult> ValidateAsync(FileTypeModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>62d5d33b5e2eb5aae5b389601d578591</Hash>
</Codenesium>*/