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
	public abstract class AbstractChainStatuService : AbstractService
	{
		protected IChainStatuRepository ChainStatuRepository { get; private set; }

		protected IApiChainStatuRequestModelValidator ChainStatuModelValidator { get; private set; }

		protected IBOLChainStatuMapper BolChainStatuMapper { get; private set; }

		protected IDALChainStatuMapper DalChainStatuMapper { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractChainStatuService(
			ILogger logger,
			IChainStatuRepository chainStatuRepository,
			IApiChainStatuRequestModelValidator chainStatuModelValidator,
			IBOLChainStatuMapper bolChainStatuMapper,
			IDALChainStatuMapper dalChainStatuMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.ChainStatuRepository = chainStatuRepository;
			this.ChainStatuModelValidator = chainStatuModelValidator;
			this.BolChainStatuMapper = bolChainStatuMapper;
			this.DalChainStatuMapper = dalChainStatuMapper;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainStatuResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChainStatuRepository.All(limit, offset);

			return this.BolChainStatuMapper.MapBOToModel(this.DalChainStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainStatuResponseModel> Get(int id)
		{
			var record = await this.ChainStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainStatuMapper.MapBOToModel(this.DalChainStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiChainStatuResponseModel>> Create(
			ApiChainStatuRequestModel model)
		{
			CreateResponse<ApiChainStatuResponseModel> response = new CreateResponse<ApiChainStatuResponseModel>(await this.ChainStatuModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolChainStatuMapper.MapModelToBO(default(int), model);
				var record = await this.ChainStatuRepository.Create(this.DalChainStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolChainStatuMapper.MapBOToModel(this.DalChainStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainStatuResponseModel>> Update(
			int id,
			ApiChainStatuRequestModel model)
		{
			var validationResult = await this.ChainStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChainStatuMapper.MapModelToBO(id, model);
				await this.ChainStatuRepository.Update(this.DalChainStatuMapper.MapBOToEF(bo));

				var record = await this.ChainStatuRepository.Get(id);

				return new UpdateResponse<ApiChainStatuResponseModel>(this.BolChainStatuMapper.MapBOToModel(this.DalChainStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiChainStatuResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ChainStatuModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ChainStatuRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiChainStatuResponseModel> ByName(string name)
		{
			ChainStatu record = await this.ChainStatuRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainStatuMapper.MapBOToModel(this.DalChainStatuMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.ChainStatuRepository.Chains(chainStatusId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>6f15e8ef78bfaeaebfd593091bf94aa2</Hash>
</Codenesium>*/