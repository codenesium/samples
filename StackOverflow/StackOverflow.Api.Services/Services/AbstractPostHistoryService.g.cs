using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryService : AbstractService
	{
		private IPostHistoryRepository postHistoryRepository;

		private IApiPostHistoryRequestModelValidator postHistoryModelValidator;

		private IBOLPostHistoryMapper bolPostHistoryMapper;

		private IDALPostHistoryMapper dalPostHistoryMapper;

		private ILogger logger;

		public AbstractPostHistoryService(
			ILogger logger,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolPostHistoryMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.postHistoryRepository = postHistoryRepository;
			this.postHistoryModelValidator = postHistoryModelValidator;
			this.bolPostHistoryMapper = bolPostHistoryMapper;
			this.dalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.postHistoryRepository.All(limit, offset);

			return this.bolPostHistoryMapper.MapBOToModel(this.dalPostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryResponseModel> Get(int id)
		{
			var record = await this.postHistoryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolPostHistoryMapper.MapBOToModel(this.dalPostHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryResponseModel>> Create(
			ApiPostHistoryRequestModel model)
		{
			CreateResponse<ApiPostHistoryResponseModel> response = new CreateResponse<ApiPostHistoryResponseModel>(await this.postHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPostHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.postHistoryRepository.Create(this.dalPostHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPostHistoryMapper.MapBOToModel(this.dalPostHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryResponseModel>> Update(
			int id,
			ApiPostHistoryRequestModel model)
		{
			var validationResult = await this.postHistoryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolPostHistoryMapper.MapModelToBO(id, model);
				await this.postHistoryRepository.Update(this.dalPostHistoryMapper.MapBOToEF(bo));

				var record = await this.postHistoryRepository.Get(id);

				return new UpdateResponse<ApiPostHistoryResponseModel>(this.bolPostHistoryMapper.MapBOToModel(this.dalPostHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.postHistoryModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.postHistoryRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ec6c4fdd6fe9769370a35f17db2518af</Hash>
</Codenesium>*/