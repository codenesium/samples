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
    <Hash>359c132ba5e38a8ac4375d2bf378b484</Hash>
</Codenesium>*/