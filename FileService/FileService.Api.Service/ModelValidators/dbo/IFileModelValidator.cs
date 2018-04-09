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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>e0dafb44db089fc7237b7dc42e979e6d</Hash>
</Codenesium>*/