using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTimestampCheckService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITimestampCheckRepository TimestampCheckRepository { get; private set; }

		protected IApiTimestampCheckServerRequestModelValidator TimestampCheckModelValidator { get; private set; }

		protected IDALTimestampCheckMapper DalTimestampCheckMapper { get; private set; }

		private ILogger logger;

		public AbstractTimestampCheckService(
			ILogger logger,
			MediatR.IMediator mediator,
			ITimestampCheckRepository timestampCheckRepository,
			IApiTimestampCheckServerRequestModelValidator timestampCheckModelValidator,
			IDALTimestampCheckMapper dalTimestampCheckMapper)
			: base()
		{
			this.TimestampCheckRepository = timestampCheckRepository;
			this.TimestampCheckModelValidator = timestampCheckModelValidator;
			this.DalTimestampCheckMapper = dalTimestampCheckMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTimestampCheckServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<TimestampCheck> records = await this.TimestampCheckRepository.All(limit, offset, query);

			return this.DalTimestampCheckMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTimestampCheckServerResponseModel> Get(int id)
		{
			TimestampCheck record = await this.TimestampCheckRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTimestampCheckMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTimestampCheckServerResponseModel>> Create(
			ApiTimestampCheckServerRequestModel model)
		{
			CreateResponse<ApiTimestampCheckServerResponseModel> response = ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.CreateResponse(await this.TimestampCheckModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				TimestampCheck record = this.DalTimestampCheckMapper.MapModelToEntity(default(int), model);
				record = await this.TimestampCheckRepository.Create(record);

				response.SetRecord(this.DalTimestampCheckMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TimestampCheckCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTimestampCheckServerResponseModel>> Update(
			int id,
			ApiTimestampCheckServerRequestModel model)
		{
			var validationResult = await this.TimestampCheckModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				TimestampCheck record = this.DalTimestampCheckMapper.MapModelToEntity(id, model);
				await this.TimestampCheckRepository.Update(record);

				record = await this.TimestampCheckRepository.Get(id);

				ApiTimestampCheckServerResponseModel apiModel = this.DalTimestampCheckMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TimestampCheckUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTimestampCheckServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TimestampCheckModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TimestampCheckRepository.Delete(id);

				await this.mediator.Publish(new TimestampCheckDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ab907db65b46e1f50bfdaa00c072d22</Hash>
</Codenesium>*/