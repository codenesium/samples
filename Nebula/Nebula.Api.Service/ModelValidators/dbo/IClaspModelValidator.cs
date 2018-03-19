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
    <Hash>4d1976eb12e2c4c88f3ad9816a145718</Hash>
</Codenesium>*/