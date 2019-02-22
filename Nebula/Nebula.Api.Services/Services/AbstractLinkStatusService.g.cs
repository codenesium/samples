using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkStatusService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ILinkStatusRepository LinkStatusRepository { get; private set; }

		protected IApiLinkStatusServerRequestModelValidator LinkStatusModelValidator { get; private set; }

		protected IDALLinkStatusMapper DalLinkStatusMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkStatusService(
			ILogger logger,
			MediatR.IMediator mediator,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusServerRequestModelValidator linkStatusModelValidator,
			IDALLinkStatusMapper dalLinkStatusMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.LinkStatusRepository = linkStatusRepository;
			this.LinkStatusModelValidator = linkStatusModelValidator;
			this.DalLinkStatusMapper = dalLinkStatusMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<LinkStatus> records = await this.LinkStatusRepository.All(limit, offset, query);

			return this.DalLinkStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLinkStatusServerResponseModel> Get(int id)
		{
			LinkStatus record = await this.LinkStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLinkStatusServerResponseModel>> Create(
			ApiLinkStatusServerRequestModel model)
		{
			CreateResponse<ApiLinkStatusServerResponseModel> response = ValidationResponseFactory<ApiLinkStatusServerResponseModel>.CreateResponse(await this.LinkStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				LinkStatus record = this.DalLinkStatusMapper.MapModelToEntity(default(int), model);
				record = await this.LinkStatusRepository.Create(record);

				response.SetRecord(this.DalLinkStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LinkStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkStatusServerResponseModel>> Update(
			int id,
			ApiLinkStatusServerRequestModel model)
		{
			var validationResult = await this.LinkStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				LinkStatus record = this.DalLinkStatusMapper.MapModelToEntity(id, model);
				await this.LinkStatusRepository.Update(record);

				record = await this.LinkStatusRepository.Get(id);

				ApiLinkStatusServerResponseModel apiModel = this.DalLinkStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LinkStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkStatusRepository.Delete(id);

				await this.mediator.Publish(new LinkStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiLinkStatusServerResponseModel> ByName(string name)
		{
			LinkStatus record = await this.LinkStatusRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkStatusMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> LinksByLinkStatusId(int linkStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.LinkStatusRepository.LinksByLinkStatusId(linkStatusId, limit, offset);

			return this.DalLinkMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5df9996d922ace2f4696fc630e177b46</Hash>
</Codenesium>*/