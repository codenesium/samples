using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDocumentService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IDocumentRepository DocumentRepository { get; private set; }

		protected IApiDocumentServerRequestModelValidator DocumentModelValidator { get; private set; }

		protected IDALDocumentMapper DalDocumentMapper { get; private set; }

		private ILogger logger;

		public AbstractDocumentService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<Document> records = await this.DocumentRepository.All(limit, offset, query);

			return this.DalDocumentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDocumentServerResponseModel> Get(Guid rowguid)
		{
			Document record = await this.DocumentRepository.Get(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDocumentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDocumentServerResponseModel>> Create(
			ApiDocumentServerRequestModel model)
		{
			CreateResponse<ApiDocumentServerResponseModel> response = ValidationResponseFactory<ApiDocumentServerResponseModel>.CreateResponse(await this.DocumentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Document record = this.DalDocumentMapper.MapModelToEntity(default(Guid), model);
				record = await this.DocumentRepository.Create(record);

				response.SetRecord(this.DalDocumentMapper.MapEntityToModel(record));
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
				Document record = this.DalDocumentMapper.MapModelToEntity(rowguid, model);
				await this.DocumentRepository.Update(record);

				record = await this.DocumentRepository.Get(rowguid);

				ApiDocumentServerResponseModel apiModel = this.DalDocumentMapper.MapEntityToModel(record);
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
				return this.DalDocumentMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiDocumentServerResponseModel>> ByFileNameRevision(string fileName, string revision, int limit = 0, int offset = int.MaxValue)
		{
			List<Document> records = await this.DocumentRepository.ByFileNameRevision(fileName, revision, limit, offset);

			return this.DalDocumentMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f105d71fc3e6ff57fa2b55bf41f563d7</Hash>
</Codenesium>*/