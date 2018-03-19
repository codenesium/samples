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
    <Hash>5b225233abadc636f932c0431d06bcdb</Hash>
</Codenesium>*/