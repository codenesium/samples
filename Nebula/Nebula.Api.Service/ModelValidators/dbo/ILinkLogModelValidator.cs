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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>efdce6a4c4139280ac05c98cd2b52c31</Hash>
</Codenesium>*/