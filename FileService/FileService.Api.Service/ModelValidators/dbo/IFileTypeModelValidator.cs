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
    <Hash>60e885493eb0d8b812c6ab2ae11c5e42</Hash>
</Codenesium>*/