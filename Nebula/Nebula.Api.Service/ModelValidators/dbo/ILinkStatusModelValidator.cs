using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface ILinkStatusModelValidator
	{
		ValidationResult Validate(LinkStatusModel entity);

		Task<ValidationResult> ValidateAsync(LinkStatusModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>8796d9411670acb95292e0e79ac13df8</Hash>
</Codenesium>*/