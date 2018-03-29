using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IStateProvinceModelValidator
	{
		ValidationResult Validate(StateProvinceModel entity);

		Task<ValidationResult> ValidateAsync(StateProvinceModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>0ec7a0ed8063ea84663e7d81ecbe86a3</Hash>
</Codenesium>*/