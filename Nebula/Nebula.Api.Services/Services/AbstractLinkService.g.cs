using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkService : AbstractService
	{
		private IMediator mediator;

		protected ILinkRepository LinkRepository { get; private set; }

		protected IApiLinkServerRequestModelValidator LinkModelValidator { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkService(
			ILogger logger,
			IMediator mediator,
			ILinkRepository linkRepository,
			IApiLinkServerRequestModelValidator linkModelValidator,
			IDALLinkMapper dalLinkMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkRepository = linkRepository;
			this.LinkModelValidator = linkModelValidator;
			this.DalLinkMapper = dalLinkMapper;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLinkServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Link> records = await this.LinkRepository.All(limit, offset, query);

			return this.DalLinkMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLinkServerResponseModel> Get(int id)
		{
			Link record = await this.LinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLinkServerResponseModel>> Create(
			ApiLinkServerRequestModel model)
		{
			CreateResponse<ApiLinkServerResponseModel> response = ValidationResponseFactory<ApiLinkServerResponseModel>.CreateResponse(await this.LinkModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Link record = this.DalLinkMapper.MapModelToEntity(default(int), model);
				record = await this.LinkRepository.Create(record);

				response.SetRecord(this.DalLinkMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LinkCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkServerResponseModel>> Update(
			int id,
			ApiLinkServerRequestModel model)
		{
			var validationResult = await this.LinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Link record = this.DalLinkMapper.MapModelToEntity(id, model);
				await this.LinkRepository.Update(record);

				record = await this.LinkRepository.Get(id);

				ApiLinkServerResponseModel apiModel = this.DalLinkMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LinkUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLinkServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLinkServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkRepository.Delete(id);

				await this.mediator.Publish(new LinkDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiLinkServerResponseModel> ByExternalId(Guid externalId)
		{
			Link record = await this.LinkRepository.ByExternalId(externalId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLinkMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> ByChainId(int chainId, int limit = 0, int offset = int.MaxValue)
		{
			List<Link> records = await this.LinkRepository.ByChainId(chainId, limit, offset);

			return this.DalLinkMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiLinkLogServerResponseModel>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0)
		{
			List<LinkLog> records = await this.LinkRepository.LinkLogsByLinkId(linkId, limit, offset);

			return this.DalLinkLogMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f30fc0c255b8e498ce56999ec3f1eec2</Hash>
</Codenesium>*/