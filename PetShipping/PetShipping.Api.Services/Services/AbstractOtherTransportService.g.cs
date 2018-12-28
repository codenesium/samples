using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractOtherTransportService : AbstractService
	{
		private IMediator mediator;

		protected IOtherTransportRepository OtherTransportRepository { get; private set; }

		protected IApiOtherTransportServerRequestModelValidator OtherTransportModelValidator { get; private set; }

		protected IBOLOtherTransportMapper BolOtherTransportMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractOtherTransportService(
			ILogger logger,
			IMediator mediator,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportServerRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolOtherTransportMapper,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base()
		{
			this.OtherTransportRepository = otherTransportRepository;
			this.OtherTransportModelValidator = otherTransportModelValidator;
			this.BolOtherTransportMapper = bolOtherTransportMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOtherTransportServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.OtherTransportRepository.All(limit, offset);

			return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOtherTransportServerResponseModel> Get(int id)
		{
			var record = await this.OtherTransportRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolOtherTransportMapper.MapBOToModel(this.DalOtherTransportMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiOtherTransportServerResponseModel>> Create(
			ApiOtherTransportServerRequestModel model)
		{
			CreateResponse<ApiOtherTransportServerResponseModel> response = ValidationResponseFactory<ApiOtherTransportServerResponseModel>.CreateResponse(await this.OtherTransportModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolOtherTransportMapper.MapModelToBO(default(int), model);
				var record = await this.OtherTransportRepository.Create(this.DalOtherTransportMapper.MapBOToEF(bo));

				var businessObject = this.DalOtherTransportMapper.MapEFToBO(record);
				response.SetRecord(this.BolOtherTransportMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new OtherTransportCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOtherTransportServerResponseModel>> Update(
			int id,
			ApiOtherTransportServerRequestModel model)
		{
			var validationResult = await this.OtherTransportModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolOtherTransportMapper.MapModelToBO(id, model);
				await this.OtherTransportRepository.Update(this.DalOtherTransportMapper.MapBOToEF(bo));

				var record = await this.OtherTransportRepository.Get(id);

				var businessObject = this.DalOtherTransportMapper.MapEFToBO(record);
				var apiModel = this.BolOtherTransportMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new OtherTransportUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOtherTransportServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOtherTransportServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OtherTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OtherTransportRepository.Delete(id);

				await this.mediator.Publish(new OtherTransportDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ab774cf852189e9ba0f0199faf4b6a2a</Hash>
</Codenesium>*/