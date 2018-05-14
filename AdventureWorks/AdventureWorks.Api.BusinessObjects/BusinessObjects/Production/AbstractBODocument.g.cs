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
	public abstract class AbstractBODocument
	{
		private IDocumentRepository documentRepository;
		private IApiDocumentModelValidator documentModelValidator;
		private ILogger logger;

		public AbstractBODocument(
			ILogger logger,
			IDocumentRepository documentRepository,
			IApiDocumentModelValidator documentModelValidator)

		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.logger = logger;
		}

		public virtual List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.documentRepository.All(skip, take, orderClause);
		}

		public virtual POCODocument Get(Guid documentNode)
		{
			return this.documentRepository.Get(documentNode);
		}

		public virtual async Task<CreateResponse<POCODocument>> Create(
			ApiDocumentModel model)
		{
			CreateResponse<POCODocument> response = new CreateResponse<POCODocument>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODocument record = this.documentRepository.Create(model);
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
				this.documentRepository.Update(documentNode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			Guid documentNode)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateDeleteAsync(documentNode));

			if (response.Success)
			{
				this.documentRepository.Delete(documentNode);
			}
			return response;
		}

		public POCODocument GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			return this.documentRepository.GetDocumentLevelDocumentNode(documentLevel,documentNode);
		}

		public List<POCODocument> GetFileNameRevision(string fileName,string revision)
		{
			return this.documentRepository.GetFileNameRevision(fileName,revision);
		}
	}
}

/*<Codenesium>
    <Hash>791ed73de8cc80a2d190fb86fe96c7e3</Hash>
</Codenesium>*/