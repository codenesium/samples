using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5252127e4dfcff61bbf0307e91341009</Hash>
</Codenesium>*/