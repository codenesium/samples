using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IAdminModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AdminModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AdminModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b207430ed28af17539401e463d62b4d0</Hash>
</Codenesium>*/