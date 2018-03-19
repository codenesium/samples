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
    <Hash>c775e5afa50a01722d998ea1c5bbea91</Hash>
</Codenesium>*/