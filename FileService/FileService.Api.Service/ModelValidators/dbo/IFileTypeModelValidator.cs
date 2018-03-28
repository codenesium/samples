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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>135b9dcce4b3a9cd329d131ac06f5cbf</Hash>
</Codenesium>*/