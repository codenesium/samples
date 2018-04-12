using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IRateModelValidator
	{
		ValidationResult Validate(RateModel entity);

		Task<ValidationResult> ValidateAsync(RateModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>b501b331e2bec680cf9415bb714afaec</Hash>
</Codenesium>*/