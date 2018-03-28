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
    <Hash>a03bffa7b5bfb6672577cc13240396b6</Hash>
</Codenesium>*/