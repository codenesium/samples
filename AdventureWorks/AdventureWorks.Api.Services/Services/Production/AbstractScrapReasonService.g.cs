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

		protected IBOLScrapReasonMapper BolScrapReasonMapper { get; private set; }

		protected IDALScrapReasonMapper DalScrapReasonMapper { get; private set; }

		protected IBOLWorkOrderMapper BolWorkOrderMapper { get; private set; }

		protected IDALWorkOrderMapper DalWorkOrderMapper { get; private set; }

		private ILogger logger;

		public AbstractScrapReasonService(
			ILogger logger,
			IMediator mediator,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonServerRequestModelValidator scrapReasonModelValidator,
			IBOLScrapReasonMapper bolScrapReasonMapper,
			IDALScrapReasonMapper dalScrapReasonMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base()
		{
			this.ScrapReasonRepository = scrapReasonRepository;
			this.ScrapReasonModelValidator = scrapReasonModelValidator;
			this.BolScrapReasonMapper = bolScrapReasonMapper;
			this.DalScrapReasonMapper = dalScrapReasonMapper;
			this.BolWorkOrderMapper = bolWorkOrderMapper;
			this.DalWorkOrderMapper = dalWorkOrderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiScrapReasonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ScrapReasonRepository.All(limit, offset);

			return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(records));
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
				return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiScrapReasonServerResponseModel>> Create(
			ApiScrapReasonServerRequestModel model)
		{
			CreateResponse<ApiScrapReasonServerResponseModel> response = ValidationResponseFactory<ApiScrapReasonServerResponseModel>.CreateResponse(await this.ScrapReasonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolScrapReasonMapper.MapModelToBO(default(short), model);
				var record = await this.ScrapReasonRepository.Create(this.DalScrapReasonMapper.MapBOToEF(bo));

				var businessObject = this.DalScrapReasonMapper.MapEFToBO(record);
				response.SetRecord(this.BolScrapReasonMapper.MapBOToModel(businessObject));
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
				var bo = this.BolScrapReasonMapper.MapModelToBO(scrapReasonID, model);
				await this.ScrapReasonRepository.Update(this.DalScrapReasonMapper.MapBOToEF(bo));

				var record = await this.ScrapReasonRepository.Get(scrapReasonID);

				var businessObject = this.DalScrapReasonMapper.MapEFToBO(record);
				var apiModel = this.BolScrapReasonMapper.MapBOToModel(businessObject);
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
				return this.BolScrapReasonMapper.MapBOToModel(this.DalScrapReasonMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiWorkOrderServerResponseModel>> WorkOrdersByScrapReasonID(short scrapReasonID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrder> records = await this.ScrapReasonRepository.WorkOrdersByScrapReasonID(scrapReasonID, limit, offset);

			return this.BolWorkOrderMapper.MapBOToModel(this.DalWorkOrderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>05cbbeb88297f4dc11d6e63bffb38453</Hash>
</Codenesium>*/