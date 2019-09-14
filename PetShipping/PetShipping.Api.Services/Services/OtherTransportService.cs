using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class OtherTransportService : AbstractService, IOtherTransportService
	{
		private MediatR.IMediator mediator;

		protected IOtherTransportRepository OtherTransportRepository { get; private set; }

		protected IApiOtherTransportServerRequestModelValidator OtherTransportModelValidator { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		private ILogger logger;

		public OtherTransportService(
			ILogger<IOtherTransportService> logger,
			MediatR.IMediator mediator,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportServerRequestModelValidator otherTransportModelValidator,
			IDALOtherTransportMapper dalOtherTransportMapper)
			: base()
		{
			this.OtherTransportRepository = otherTransportRepository;
			this.OtherTransportModelValidator = otherTransportModelValidator;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOtherTransportServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OtherTransport> records = await this.OtherTransportRepository.All(limit, offset, query);

			return this.DalOtherTransportMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOtherTransportServerResponseModel> Get(int id)
		{
			OtherTransport record = await this.OtherTransportRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOtherTransportMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOtherTransportServerResponseModel>> Create(
			ApiOtherTransportServerRequestModel model)
		{
			CreateResponse<ApiOtherTransportServerResponseModel> response = ValidationResponseFactory<ApiOtherTransportServerResponseModel>.CreateResponse(await this.OtherTransportModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				OtherTransport record = this.DalOtherTransportMapper.MapModelToEntity(default(int), model);
				record = await this.OtherTransportRepository.Create(record);

				response.SetRecord(this.DalOtherTransportMapper.MapEntityToModel(record));
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
				OtherTransport record = this.DalOtherTransportMapper.MapModelToEntity(id, model);
				await this.OtherTransportRepository.Update(record);

				record = await this.OtherTransportRepository.Get(id);

				ApiOtherTransportServerResponseModel apiModel = this.DalOtherTransportMapper.MapEntityToModel(record);
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
    <Hash>db366ababdfd714d3bc40a7a56d77078</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/