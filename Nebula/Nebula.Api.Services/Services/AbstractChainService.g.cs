using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractChainService : AbstractService
	{
		protected IChainRepository ChainRepository { get; private set; }

		protected IApiChainRequestModelValidator ChainModelValidator { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractChainService(
			ILogger logger,
			IChainRepository chainRepository,
			IApiChainRequestModelValidator chainModelValidator,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.ChainRepository = chainRepository;
			this.ChainModelValidator = chainModelValidator;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChainRepository.All(limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiChainResponseModel>> Create(
			ApiChainRequestModel model)
		{
			CreateResponse<ApiChainResponseModel> response = new CreateResponse<ApiChainResponseModel>(await this.ChainModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolChainMapper.MapModelToBO(default(int), model);
				var record = await this.ChainRepository.Create(this.DalChainMapper.MapBOToEF(bo));

				response.SetRecord(this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainResponseModel>> Update(
			int id,
			ApiChainRequestModel model)
		{
			var validationResult = await this.ChainModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChainMapper.MapModelToBO(id, model);
				await this.ChainRepository.Update(this.DalChainMapper.MapBOToEF(bo));

				var record = await this.ChainRepository.Get(id);

				return new UpdateResponse<ApiChainResponseModel>(this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiChainResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ChainModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ChainRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiChainResponseModel> ByExternalId(Guid externalId)
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

		public async virtual Task<List<ApiLinkResponseModel>> Links(int chainId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.ChainRepository.Links(chainId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiChainResponseModel>> ByPreviousChainId(int previousChainId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.ChainRepository.ByPreviousChainId(previousChainId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b5a62c284a62c4db6dc2227581c59ead</Hash>
</Codenesium>*/