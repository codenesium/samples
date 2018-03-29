using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IDocumentModelValidator
	{
		ValidationResult Validate(DocumentModel entity);

		Task<ValidationResult> ValidateAsync(DocumentModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>1e6b315f573d94f70bec70bab58f982e</Hash>
</Codenesium>*/