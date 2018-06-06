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
		private IBOLDocumentMapper bolDocumentMapper;
		private IDALDocumentMapper dalDocumentMapper;
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
			this.bolDocumentMapper = boldocumentMapper;
			this.dalDocumentMapper = daldocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.documentRepository.All(skip, take, orderClause);

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDocumentResponseModel> Get(Guid documentNode)
		{
			var record = await documentRepository.Get(documentNode);

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDocumentMapper.MapModelToBO(default (Guid), model);
				var record = await this.documentRepository.Create(this.dalDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record)));
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
				var bo = this.bolDocumentMapper.MapModelToBO(documentNode, model);
				await this.documentRepository.Update(this.dalDocumentMapper.MapBOToEF(bo));
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

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record));
		}
		public async Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName,string revision)
		{
			List<Document> records = await this.documentRepository.GetFileNameRevision(fileName,revision);

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>2896033facbd4b28571f3e9dc510be19</Hash>
</Codenesium>*/