using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkLogModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkLogModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkLogModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13e5e3a5ed44f487dc4902ac79f4e424</Hash>
</Codenesium>*/