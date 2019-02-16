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
			var records = await this.ScrapReasonRepository.All(limit, offset, query);

			return this.DalScrapReasonMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiScrapReasonServerResponseModel> Get(short scrapReasonID)
		{
			var record = await this.ScrapReasonRepository.Get(scrapReasonID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalScrapReasonMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiScrapReasonServerResponseModel>> Create(
			ApiScrapReasonServerRequestModel model)
		{
			CreateResponse<ApiScrapReasonServerResponseModel> response = ValidationResponseFactory<ApiScrapReasonServerResponseModel>.CreateResponse(await this.ScrapReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalScrapReasonMapper.MapModelToBO(default(short), model);
				var record = await this.ScrapReasonRepository.Create(bo);

				response.SetRecord(this.DalScrapReasonMapper.MapBOToModel(record));
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
				var bo = this.DalScrapReasonMapper.MapModelToBO(scrapReasonID, model);
				await this.ScrapReasonRepository.Update(bo);

				var record = await this.ScrapReasonRepository.Get(scrapReasonID);

				var apiModel = this.DalScrapReasonMapper.MapBOToModel(record);
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
				return this.DalScrapReasonMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ScrapReasonRepository.WorkOrdersByScrapReasonID(scrapReasonID, limit, offset);

			return this.DalWorkOrderMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5c7b4f0aa800fcdfc3372682d5d93e6f</Hash>
</Codenesium>*/