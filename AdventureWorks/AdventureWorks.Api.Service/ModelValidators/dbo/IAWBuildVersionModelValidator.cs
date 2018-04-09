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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>2a32dc931c82d74b097a7e0c87444c2f</Hash>
</Codenesium>*/