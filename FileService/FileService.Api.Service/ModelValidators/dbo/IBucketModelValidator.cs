using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Service
{
	public interface IBucketModelValidator
	{
		ValidationResult Validate(BucketModel entity);

		Task<ValidationResult> ValidateAsync(BucketModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e31143f027990037f96659ac6331a537</Hash>
</Codenesium>*/