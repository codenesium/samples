using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractChainService : AbstractService
	{
		private IMediator mediator;

		protected IChainRepository ChainRepository { get; private set; }

		protected IApiChainServerRequestModelValidator ChainModelValidator { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		protected IBOLClaspMapper BolClaspMapper { get; private set; }

		protected IDALClaspMapper DalClaspMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractChainService(
			ILogger logger,
			IMediator mediator,
			IChainRepository chainRepository,
			IApiChainServerRequestModelValidator chainModelValidator,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper,
			IBOLClaspMapper bolClaspMapper,
			IDALClaspMapper dalClaspMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.ChainRepository = chainRepository;
			this.ChainModelValidator = chainModelValidator;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.BolClaspMapper = bolClaspMapper;
			this.DalClaspMapper = dalClaspMapper;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiChainServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChainRepository.All(limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainServerResponseModel> Get(int id)
		{
			var record = await this.ChainRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiChainServerResponseModel>> Create(
			ApiChainServerRequestModel model)
		{
			CreateResponse<ApiChainServerResponseModel> response = ValidationResponseFactory<ApiChainServerResponseModel>.CreateResponse(await this.ChainModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolChainMapper.MapModelToBO(default(int), model);
				var record = await this.ChainRepository.Create(this.DalChainMapper.MapBOToEF(bo));

				var businessObject = this.DalChainMapper.MapEFToBO(record);
				response.SetRecord(this.BolChainMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ChainCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainServerResponseModel>> Update(
			int id,
			ApiChainServerRequestModel model)
		{
			var validationResult = await this.ChainModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChainMapper.MapModelToBO(id, model);
				await this.ChainRepository.Update(this.DalChainMapper.MapBOToEF(bo));

				var record = await this.ChainRepository.Get(id);

				var businessObject = this.DalChainMapper.MapEFToBO(record);
				var apiModel = this.BolChainMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ChainUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiChainServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiChainServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ChainModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ChainRepository.Delete(id);

				await this.mediator.Publish(new ChainDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiChainServerResponseModel> ByExternalId(Guid externalId)
		{
			Chain record = await this.ChainRepository.ByExternalId(externalId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiClaspServerResponseModel>> ClaspsByNextChainId(int nextChainId, int limit = int.MaxValue, int offset = 0)
		{
			List<Clasp> records = await this.ChainRepository.ClaspsByNextChainId(nextChainId, limit, offset);

			return this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiClaspServerResponseModel>> ClaspsByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0)
		{
			List<Clasp> records = await this.ChainRepository.ClaspsByPreviousChainId(previousChainId, limit, offset);

			return this.BolClaspMapper.MapBOToModel(this.DalClaspMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> LinksByChainId(int chainId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.ChainRepository.LinksByChainId(chainId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>efe06ecbc8f7aa55a64cbac94ba7317b</Hash>
</Codenesium>*/