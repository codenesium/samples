using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDocumentService : AbstractService
	{
		private IMediator mediator;

		protected IDocumentRepository DocumentRepository { get; private set; }

		protected IApiDocumentServerRequestModelValidator DocumentModelValidator { get; private set; }

		protected IDALDocumentMapper DalDocumentMapper { get; private set; }

		private ILogger logger;

		public AbstractDocumentService(
			ILogger logger,
			IMediator mediator,
			IDocumentRepository documentRepository,
			IApiDocumentServerRequestModelValidator documentModelValidator,
			IDALDocumentMapper dalDocumentMapper)
			: base()
		{
			this.DocumentRepository = documentRepository;
			this.DocumentModelValidator = documentModelValidator;
			this.DalDocumentMapper = dalDocumentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDocumentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.DocumentRepository.All(limit, offset, query);

			return this.DalDocumentMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiDocumentServerResponseModel> Get(Guid rowguid)
		{
			var record = await this.DocumentRepository.Get(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDocumentMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDocumentServerResponseModel>> Create(
			ApiDocumentServerRequestModel model)
		{
			CreateResponse<ApiDocumentServerResponseModel> response = ValidationResponseFactory<ApiDocumentServerResponseModel>.CreateResponse(await this.DocumentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalDocumentMapper.MapModelToBO(default(Guid), model);
				var record = await this.DocumentRepository.Create(bo);

				response.SetRecord(this.DalDocumentMapper.MapBOToModel(record));
				await this.mediator.Publish(new DocumentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDocumentServerResponseModel>> Update(
			Guid rowguid,
			ApiDocumentServerRequestModel model)
		{
			var validationResult = await this.DocumentModelValidator.ValidateUpdateAsync(rowguid, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalDocumentMapper.MapModelToBO(rowguid, model);
				await this.DocumentRepository.Update(bo);

				var record = await this.DocumentRepository.Get(rowguid);

				var apiModel = this.DalDocumentMapper.MapBOToModel(record);
				await this.mediator.Publish(new DocumentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDocumentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDocumentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			Guid rowguid)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DocumentModelValidator.ValidateDeleteAsync(rowguid));

			if (response.Success)
			{
				await this.DocumentRepository.Delete(rowguid);

				await this.mediator.Publish(new DocumentDeletedNotification(rowguid));
			}

			return response;
		}

		public async virtual Task<ApiDocumentServerResponseModel> ByRowguid(Guid rowguid)
		{
			Document record = await this.DocumentRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDocumentMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiDocumentServerResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = 0, int offset = int.MaxValue)
		{
			List<Document> records = await this.DocumentRepository.ByFileNameRevision(fileName, revision, limit, offset);

			return this.DalDocumentMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5ef28e8dfa65f111da3223986a479a7b</Hash>
</Codenesium>*/