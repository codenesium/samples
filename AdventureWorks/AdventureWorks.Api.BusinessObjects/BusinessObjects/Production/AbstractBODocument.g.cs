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
		private IApiDocumentRequestModelValidator documentModelValidator;
		private IBOLDocumentMapper documentMapper;
		private ILogger logger;

		public AbstractBODocument(
			ILogger logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper documentMapper)
			: base()

		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.documentMapper = documentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDocumentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.documentRepository.All(skip, take, orderClause);

			return this.documentMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiDocumentResponseModel> Get(Guid documentNode)
		{
			var record = await documentRepository.Get(documentNode);

			return this.documentMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.documentMapper.MapModelToDTO(default (Guid), model);
				var record = await this.documentRepository.Create(dto);

				response.SetRecord(this.documentMapper.MapDTOToModel(record));
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
				var dto = this.documentMapper.MapModelToDTO(documentNode, model);
				await this.documentRepository.Update(documentNode, dto);
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
			DTODocument record = await this.documentRepository.GetDocumentLevelDocumentNode(documentLevel,documentNode);

			return this.documentMapper.MapDTOToModel(record);
		}
		public async Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName,string revision)
		{
			List<DTODocument> records = await this.documentRepository.GetFileNameRevision(fileName,revision);

			return this.documentMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>89456772297ac19391d915e38e111a8e</Hash>
</Codenesium>*/