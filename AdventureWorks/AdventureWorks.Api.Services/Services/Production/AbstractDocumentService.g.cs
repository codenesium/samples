using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDocumentService : AbstractService
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
			IBOLDocumentMapper bolDocumentMapper,
			IDALDocumentMapper dalDocumentMapper)
			: base()
		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.bolDocumentMapper = bolDocumentMapper;
			this.dalDocumentMapper = dalDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDocumentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.documentRepository.All(limit, offset);

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDocumentResponseModel> Get(Guid rowguid)
		{
			var record = await this.documentRepository.Get(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDocumentMapper.MapModelToBO(default(Guid), model);
				var record = await this.documentRepository.Create(this.dalDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDocumentResponseModel>> Update(
			Guid rowguid,
			ApiDocumentRequestModel model)
		{
			var validationResult = await this.documentModelValidator.ValidateUpdateAsync(rowguid, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolDocumentMapper.MapModelToBO(rowguid, model);
				await this.documentRepository.Update(this.dalDocumentMapper.MapBOToEF(bo));

				var record = await this.documentRepository.Get(rowguid);

				return new UpdateResponse<ApiDocumentResponseModel>(this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDocumentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			Guid rowguid)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateDeleteAsync(rowguid));
			if (response.Success)
			{
				await this.documentRepository.Delete(rowguid);
			}

			return response;
		}

		public async Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision)
		{
			List<Document> records = await this.documentRepository.ByFileNameRevision(fileName, revision);

			return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>266644b3bb4f6289b3afe38187fcf700</Hash>
</Codenesium>*/