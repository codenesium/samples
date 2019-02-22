using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkLogService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ILinkLogRepository LinkLogRepository { get; private set; }

		protected IApiLinkLogServerRequestModelValidator LinkLogModelValidator { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkLogService(
			ILogger logger,
			MediatR.IMediator mediator,
			ILinkLogRepository linkLogRepository,
			IApiLinkLogServerRequestModelValidator linkLogModelValidator,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkLogRepository = linkLogRepository;
			this.LinkLogModelValidator = linkLogModelValidator;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<LinkLog> records = await this.LinkLogRepository.All(limit, offset, query);

			return this.DalLinkLogMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLinkLogServerResponseModel> Get(int id)
		{
			LinkLog record = await this.LinkLogRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkLogMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLinkLogServerResponseModel>> Create(
			ApiLinkLogServerRequestModel model)
		{
			CreateResponse<ApiLinkLogServerResponseModel> response = ValidationResponseFactory<ApiLinkLogServerResponseModel>.CreateResponse(await this.LinkLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				LinkLog record = this.DalLinkLogMapper.MapModelToEntity(default(int), model);
				record = await this.LinkLogRepository.Create(record);

				response.SetRecord(this.DalLinkLogMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LinkLogCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkLogServerResponseModel>> Update(
			int id,
			ApiLinkLogServerRequestModel model)
		{
			var validationResult = await this.LinkLogModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				LinkLog record = this.DalLinkLogMapper.MapModelToEntity(id, model);
				await this.LinkLogRepository.Update(record);

				record = await this.LinkLogRepository.Get(id);

				ApiLinkLogServerResponseModel apiModel = this.DalLinkLogMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LinkLogUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkLogServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkLogServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkLogModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkLogRepository.Delete(id);

				await this.mediator.Publish(new LinkLogDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>633769bbfcc211a1c832867bb3d35bd4</Hash>
</Codenesium>*/