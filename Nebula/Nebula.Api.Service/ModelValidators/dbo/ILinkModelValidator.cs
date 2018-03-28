using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Service
{
	public interface ILinkModelValidator
	{
		ValidationResult Validate(LinkModel entity);

		Task<ValidationResult> ValidateAsync(LinkModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>5b23f9f74f7cb669f846d4c6f254fbca</Hash>
</Codenesium>*/