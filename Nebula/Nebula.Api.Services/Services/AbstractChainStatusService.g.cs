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
	public abstract class AbstractChainStatusService : AbstractService
	{
		protected IChainStatusRepository ChainStatusRepository { get; private set; }

		protected IApiChainStatusRequestModelValidator ChainStatusModelValidator { get; private set; }

		protected IBOLChainStatusMapper BolChainStatusMapper { get; private set; }

		protected IDALChainStatusMapper DalChainStatusMapper { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractChainStatusService(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
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

		public virtual async Task<List<ApiChainStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ChainStatusRepository.All(limit, offset);

			return this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainStatusResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model)
		{
			CreateResponse<ApiChainStatusResponseModel> response = new CreateResponse<ApiChainStatusResponseModel>(await this.ChainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolChainStatusMapper.MapModelToBO(default(int), model);
				var record = await this.ChainStatusRepository.Create(this.DalChainStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiChainStatusResponseModel>> Update(
			int id,
			ApiChainStatusRequestModel model)
		{
			var validationResult = await this.ChainStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolChainStatusMapper.MapModelToBO(id, model);
				await this.ChainStatusRepository.Update(this.DalChainStatusMapper.MapBOToEF(bo));

				var record = await this.ChainStatusRepository.Get(id);

				return new UpdateResponse<ApiChainStatusResponseModel>(this.BolChainStatusMapper.MapBOToModel(this.DalChainStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiChainStatusResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ChainStatusModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ChainStatusRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiChainStatusResponseModel> ByName(string name)
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

		public async virtual Task<List<ApiChainResponseModel>> Chains(int chainStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.ChainStatusRepository.Chains(chainStatusId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>dc15adae4c8f9b160b655c49acaeb6e3</Hash>
</Codenesium>*/