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
		protected IDocumentRepository DocumentRepository { get; private set; }

		protected IApiDocumentRequestModelValidator DocumentModelValidator { get; private set; }

		protected IBOLDocumentMapper BolDocumentMapper { get; private set; }

		protected IDALDocumentMapper DalDocumentMapper { get; private set; }

		private ILogger logger;

		public AbstractDocumentService(
			ILogger logger,
			IDocumentRepository documentRepository,
			IApiDocumentRequestModelValidator documentModelValidator,
			IBOLDocumentMapper bolDocumentMapper,
			IDALDocumentMapper dalDocumentMapper)
			: base()
		{
			this.DocumentRepository = documentRepository;
			this.DocumentModelValidator = documentModelValidator;
			this.BolDocumentMapper = bolDocumentMapper;
			this.DalDocumentMapper = dalDocumentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDocumentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DocumentRepository.All(limit, offset);

			return this.BolDocumentMapper.MapBOToModel(this.DalDocumentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDocumentResponseModel> Get(Guid rowguid)
		{
			var record = await this.DocumentRepository.Get(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDocumentMapper.MapBOToModel(this.DalDocumentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
			ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.DocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDocumentMapper.MapModelToBO(default(Guid), model);
				var record = await this.DocumentRepository.Create(this.DalDocumentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDocumentMapper.MapBOToModel(this.DalDocumentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDocumentResponseModel>> Update(
			Guid rowguid,
			ApiDocumentRequestModel model)
		{
			var validationResult = await this.DocumentModelValidator.ValidateUpdateAsync(rowguid, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDocumentMapper.MapModelToBO(rowguid, model);
				await this.DocumentRepository.Update(this.DalDocumentMapper.MapBOToEF(bo));

				var record = await this.DocumentRepository.Get(rowguid);

				return new UpdateResponse<ApiDocumentResponseModel>(this.BolDocumentMapper.MapBOToModel(this.DalDocumentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDocumentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			Guid rowguid)
		{
			ActionResponse response = new ActionResponse(await this.DocumentModelValidator.ValidateDeleteAsync(rowguid));
			if (response.Success)
			{
				await this.DocumentRepository.Delete(rowguid);
			}

			return response;
		}

		public async Task<List<ApiDocumentResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = 0, int offset = int.MaxValue)
		{
			List<Document> records = await this.DocumentRepository.ByFileNameRevision(fileName, revision, limit, offset);

			return this.BolDocumentMapper.MapBOToModel(this.DalDocumentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>19ddfb7604f7fe59301dd9b391647611</Hash>
</Codenesium>*/