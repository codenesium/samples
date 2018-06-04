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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDocumentService: AbstractService
	{
		private IDocumentRepository documentRepository;
		private IApiDocumentRequestModelValidator documentModelValidator;
		private IBOLDocumentMapper BOLDocumentMapper;
		private IDALDocumentMapper DALDocumentMapper;
		private ILogger logger;

		public AbstractDocumentService(
			ILogger logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper boldocumentMapper,
			IDALDocumentMapper daldocumentMapper)
			: base()

		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.BOLDocumentMapper = boldocumentMapper;
			this.DALDocumentMapper = daldocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.documentRepository.All(skip, take, orderClause);

			return this.BOLDocumentMapper.MapBOToModel(this.DALDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDocumentResponseModel> Get(Guid documentNode)
		{
			var record = await documentRepository.Get(documentNode);

			return this.BOLDocumentMapper.MapBOToModel(this.DALDocumentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLDocumentMapper.MapModelToBO(default (Guid), model);
				var record = await this.documentRepository.Create(this.DALDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLDocumentMapper.MapBOToModel(this.DALDocumentMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			Guid documentNode,
			ApiDocumentRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateUpdateAsync(documentNode, model));

			if (response.Success)
			{
				var bo = this.BOLDocumentMapper.MapModelToBO(documentNode, model);
				await this.documentRepository.Update(this.DALDocumentMapper.MapBOToEF(bo));
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

		public async Task<ApiDocumentResponseModel> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			Document record = await this.documentRepository.GetDocumentLevelDocumentNode(documentLevel,documentNode);

			return this.BOLDocumentMapper.MapBOToModel(this.DALDocumentMapper.MapEFToBO(record));
		}
		public async Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName,string revision)
		{
			List<Document> records = await this.documentRepository.GetFileNameRevision(fileName,revision);

			return this.BOLDocumentMapper.MapBOToModel(this.DALDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c494920d2dd95a63e35e9b891ad3573a</Hash>
</Codenesium>*/