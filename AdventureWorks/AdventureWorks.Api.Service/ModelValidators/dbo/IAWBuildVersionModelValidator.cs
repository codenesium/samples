using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IAWBuildVersionModelValidator
	{
		ValidationResult Validate(AWBuildVersionModel entity);

		Task<ValidationResult> ValidateAsync(AWBuildVersionModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>f6e3f7f4da011ed25b3e58ce51b6d490</Hash>
</Codenesium>*/