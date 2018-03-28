using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface IClaspModelValidator
	{
		ValidationResult Validate(ClaspModel entity);

		Task<ValidationResult> ValidateAsync(ClaspModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>56ae0e35b15e4f4ec18775e983fc2f3f</Hash>
</Codenesium>*/