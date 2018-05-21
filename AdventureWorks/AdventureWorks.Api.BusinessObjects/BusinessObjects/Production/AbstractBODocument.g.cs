using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBODocument: AbstractBOManager
	{
		private IDocumentRepository documentRepository;
		private IApiDocumentModelValidator documentModelValidator;
		private ILogger logger;

		public AbstractBODocument(
			ILogger logger,
			IDocumentRepository documentRepository,
			IApiDocumentModelValidator documentModelValidator)
			: base()

		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.documentRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCODocument> Get(Guid documentNode)
		{
			return this.documentRepository.Get(documentNode);
		}

		public virtual async Task<CreateResponse<POCODocument>> Create(
			ApiDocumentModel model)
		{
			CreateResponse<POCODocument> response = new CreateResponse<POCODocument>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODocument record = await this.documentRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			Guid documentNode,
			ApiDocumentModel model)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateUpdateAsync(documentNode, model));

			if (response.Success)
			{
				await this.documentRepository.Update(documentNode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			Guid documentNode)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateDeleteAsync(documentNode));

			if (response.Success)
			{
				await this.documentRepository.Delete(documentNode);
			}
			return response;
		}

		public async Task<POCODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			return await this.documentRepository.GetDocumentLevelDocumentNode(documentLevel,documentNode);
		}
		public async Task<List<POCODocument>> GetFileNameRevision(string fileName,string revision)
		{
			return await this.documentRepository.GetFileNameRevision(fileName,revision);
		}
	}
}

/*<Codenesium>
    <Hash>9203cbe7969e39f5bd73bf1d4b1eac4e</Hash>
</Codenesium>*/