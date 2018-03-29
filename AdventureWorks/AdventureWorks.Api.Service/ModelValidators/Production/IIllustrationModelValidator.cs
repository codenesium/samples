using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IIllustrationModelValidator
	{
		ValidationResult Validate(IllustrationModel entity);

		Task<ValidationResult> ValidateAsync(IllustrationModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>21204ed6986e2ca630f5d7d198daea3c</Hash>
</Codenesium>*/