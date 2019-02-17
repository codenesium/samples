using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractScrapReasonService : AbstractService
	{
		private IMediator mediator;

		protected IScrapReasonRepository ScrapReasonRepository { get; private set; }

		protected IApiScrapReasonServerRequestModelValidator ScrapReasonModelValidator { get; private set; }

		protected IDALScrapReasonMapper DalScrapReasonMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractScrapReasonService(
			ILogger logger,
			IMediator mediator,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonServerRequestModelValidator scrapReasonModelValidator,
			IDALScrapReasonMapper dalScrapReasonMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ScrapReasonRepository = scrapReasonRepository;
			this.ScrapReasonModelValidator = scrapReasonModelValidator;
			this.DalScrapReasonMapper = dalScrapReasonMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiScrapReasonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ScrapReason> records = await this.ScrapReasonRepository.All(limit, offset, query);

			return this.DalScrapReasonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiScrapReasonServerResponseModel> Get(short scrapReasonID)
		{
			ScrapReason record = await this.ScrapReasonRepository.Get(scrapReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalScrapReasonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiScrapReasonServerResponseModel>> Create(
			ApiScrapReasonServerRequestModel model)
		{
			CreateResponse<ApiScrapReasonServerResponseModel> response = ValidationResponseFactory<ApiScrapReasonServerResponseModel>.CreateResponse(await this.ScrapReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ScrapReason record = this.DalScrapReasonMapper.MapModelToEntity(default(short), model);
				record = await this.ScrapReasonRepository.Create(record);

				response.SetRecord(this.DalScrapReasonMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ScrapReasonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiScrapReasonServerResponseModel>> Update(
			short scrapReasonID,
			ApiScrapReasonServerRequestModel model)
		{
			var validationResult = await this.ScrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model);

			if (validationResult.IsValid)
			{
				ScrapReason record = this.DalScrapReasonMapper.MapModelToEntity(scrapReasonID, model);
				await this.ScrapReasonRepository.Update(record);

				record = await this.ScrapReasonRepository.Get(scrapReasonID);

				ApiScrapReasonServerResponseModel apiModel = this.DalScrapReasonMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ScrapReasonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiScrapReasonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiScrapReasonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short scrapReasonID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ScrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));

			if (response.Success)
			{
				await this.ScrapReasonRepository.Delete(scrapReasonID);

				await this.mediator.Publish(new ScrapReasonDeletedNotification(scrapReasonID));
			}

			return response;
		}

		public async virtual Task<ApiScrapReasonServerResponseModel> ByName(string name)
		{
			ScrapReason record = await this.ScrapReasonRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalScrapReasonMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ScrapReasonRepository.WorkOrdersByScrapReasonID(scrapReasonID, limit, offset);

			return this.DalWorkOrderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1f14621604a14153f429da5b43968fbf</Hash>
</Codenesium>*/