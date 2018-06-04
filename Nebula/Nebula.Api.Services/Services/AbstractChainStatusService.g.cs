using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractChainStatusService: AbstractService
	{
		private IChainStatusRepository chainStatusRepository;
		private IApiChainStatusRequestModelValidator chainStatusModelValidator;
		private IBOLChainStatusMapper BOLChainStatusMapper;
		private IDALChainStatusMapper DALChainStatusMapper;
		private ILogger logger;

		public AbstractChainStatusService(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusRequestModelValidator chainStatusModelValidator,
			IBOLChainStatusMapper bolchainStatusMapper,
			IDALChainStatusMapper dalchainStatusMapper)
			: base()

		{
			this.chainStatusRepository = chainStatusRepository;
			this.chainStatusModelValidator = chainStatusModelValidator;
			this.BOLChainStatusMapper = bolchainStatusMapper;
			this.DALChainStatusMapper = dalchainStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiChainStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.chainStatusRepository.All(skip, take, orderClause);

			return this.BOLChainStatusMapper.MapBOToModel(this.DALChainStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiChainStatusResponseModel> Get(int id)
		{
			var record = await chainStatusRepository.Get(id);

			return this.BOLChainStatusMapper.MapBOToModel(this.DALChainStatusMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiChainStatusResponseModel>> Create(
			ApiChainStatusRequestModel model)
		{
			CreateResponse<ApiChainStatusResponseModel> response = new CreateResponse<ApiChainStatusResponseModel>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLChainStatusMapper.MapModelToBO(default (int), model);
				var record = await this.chainStatusRepository.Create(this.DALChainStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLChainStatusMapper.MapBOToModel(this.DALChainStatusMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiChainStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLChainStatusMapper.MapModelToBO(id, model);
				await this.chainStatusRepository.Update(this.DALChainStatusMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.chainStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e8791019e44433924b842fa400961242</Hash>
</Codenesium>*/