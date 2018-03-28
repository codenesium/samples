using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Service
{
	public interface IFileModelValidator
	{
		ValidationResult Validate(FileModel entity);

		Task<ValidationResult> ValidateAsync(FileModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>6323b9440aeba7cbe9a28e3e680f5334</Hash>
</Codenesium>*/