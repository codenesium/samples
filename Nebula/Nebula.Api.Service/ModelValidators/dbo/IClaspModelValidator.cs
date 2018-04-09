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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>7434bf9dccb4cbdba5cb3e092d5b6702</Hash>
</Codenesium>*/