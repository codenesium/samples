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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>5efb9cb6682c66c98a19581d66ee3573</Hash>
</Codenesium>*/