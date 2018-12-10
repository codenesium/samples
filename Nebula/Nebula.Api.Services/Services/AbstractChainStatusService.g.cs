using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractChainStatusService : AbstractService
	{
		protected IChainStatusRepository ChainStatusRepository { get; private set; }

		protected IApiChainStatusServerRequestModelValidator ChainStatusModelValidator { get; private set; }

		protected IBOLChainStatusMapper BolChainStatusMapper { get; private set; }

		protected IDALChainStatusMapper DalChainStatusMapper { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractChainStatusService(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusServerRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper bolChainStatusMapper,
			IDALChainStatusMapper dalChainStatusMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.ChainStatusRepository = chainStatusRepository;
			this.ChainStatusModelValidator = chainStatusModelValidator;
			this.BolChainStatusMapper = bolChainStatusMapper;
			this.DalChainStatusMapper = dalChainStatusMapper;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChainStatusRepository.All(limit, offset);

			return this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainStatusServerResponseModel> Get(int id)
		{
			var record = await this.ChainStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiChainStatusServerResponseModel>> Create(
			ApiChainStatusServerRequestModel model)
		{
			CreateResponse<ApiChainStatusServerResponseModel> response = ValidationResponseFactory<ApiChainStatusServerResponseModel>.CreateResponse(await this.ChainStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolChainStatusMapper.MapModelToBO(default(int), model);
				var record = await this.ChainStatusRepository.Create(this.DalChainStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainStatusServerResponseModel>> Update(
			int id,
			ApiChainStatusServerRequestModel model)
		{
			var validationResult = await this.ChainStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChainStatusMapper.MapModelToBO(id, model);
				await this.ChainStatusRepository.Update(this.DalChainStatusMapper.MapBOToEF(bo));

				var record = await this.ChainStatusRepository.Get(id);

				return ValidationResponseFactory<ApiChainStatusServerResponseModel>.UpdateResponse(this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiChainStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ChainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ChainStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<ApiChainStatusServerResponseModel> ByName(string name)
		{
			ChainStatus record = await this.ChainStatusRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiChainServerResponseModel>> ChainsByChainStatusId(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.ChainStatusRepository.ChainsByChainStatusId(chainStatusId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b78a8db3911828724720b846098ec85f</Hash>
</Codenesium>*/