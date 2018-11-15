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
		protected ILinkRepository LinkRepository { get; private set; }

		protected IApiLinkServerRequestModelValidator LinkModelValidator { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		protected IBOLLinkLogMapper BolLinkLogMapper { get; private set; }

		protected IDALLinkLogMapper DalLinkLogMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkService(
			ILogger logger,
			ILinkRepository linkRepository,
			IApiLinkServerRequestModelValidator linkModelValidator,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper,
			IBOLLinkLogMapper bolLinkLogMapper,
			IDALLinkLogMapper dalLinkLogMapper)
			: base()
		{
			this.LinkRepository = linkRepository;
			this.LinkModelValidator = linkModelValidator;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.BolLinkLogMapper = bolLinkLogMapper;
			this.DalLinkLogMapper = dalLinkLogMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkRepository.All(limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkServerResponseModel> Get(int id)
		{
			var record = await this.LinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkServerResponseModel>> Create(
			ApiLinkServerRequestModel model)
		{
			CreateResponse<ApiLinkServerResponseModel> response = ValidationResponseFactory<ApiLinkServerResponseModel>.CreateResponse(await this.LinkModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLinkMapper.MapModelToBO(default(int), model);
				var record = await this.LinkRepository.Create(this.DalLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record)));
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
				var bo = this.BolLinkMapper.MapModelToBO(id, model);
				await this.LinkRepository.Update(this.DalLinkMapper.MapBOToEF(bo));

				var record = await this.LinkRepository.Get(id);

				return ValidationResponseFactory<ApiLinkServerResponseModel>.UpdateResponse(this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record)));
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
				return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> ByChainId(int chainId, int limit = 0, int offset = int.MaxValue)
		{
			List<Link> records = await this.LinkRepository.ByChainId(chainId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiLinkLogServerResponseModel>> LinkLogsByLinkId(int linkId, int limit = int.MaxValue, int offset = 0)
		{
			List<LinkLog> records = await this.LinkRepository.LinkLogsByLinkId(linkId, limit, offset);

			return this.BolLinkLogMapper.MapBOToModel(this.DalLinkLogMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3b2bca8430d6386f40a3b04a8e843dcc</Hash>
</Codenesium>*/