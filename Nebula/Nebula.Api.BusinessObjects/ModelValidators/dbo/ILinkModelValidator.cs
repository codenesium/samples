using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ca97ee2630cebecc149b6d45779f53bf</Hash>
</Codenesium>*/