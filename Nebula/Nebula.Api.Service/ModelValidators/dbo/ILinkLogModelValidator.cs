using System.Threading.Tasks;
using FluentValidation.Results;

using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Service
{
	public interface ILinkLogModelValidator
	{
		ValidationResult Validate(LinkLogModel entity);

		Task<ValidationResult> ValidateAsync(LinkLogModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>681fb8361d36fcbc39f1598601f609d9</Hash>
</Codenesium>*/