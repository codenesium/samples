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
	public abstract class AbstractPostHistoryTypeService : AbstractService
	{
		protected IPostHistoryTypeRepository PostHistoryTypeRepository { get; private set; }

		protected IApiPostHistoryTypeRequestModelValidator PostHistoryTypeModelValidator { get; private set; }

		protected IBOLPostHistoryTypeMapper BolPostHistoryTypeMapper { get; private set; }

		protected IDALPostHistoryTypeMapper DalPostHistoryTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryTypeService(
			ILogger logger,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeRequestModelValidator postHistoryTypeModelValidator,
			IBOLPostHistoryTypeMapper bolPostHistoryTypeMapper,
			IDALPostHistoryTypeMapper dalPostHistoryTypeMapper)
			: base()
		{
			this.PostHistoryTypeRepository = postHistoryTypeRepository;
			this.PostHistoryTypeModelValidator = postHistoryTypeModelValidator;
			this.BolPostHistoryTypeMapper = bolPostHistoryTypeMapper;
			this.DalPostHistoryTypeMapper = dalPostHistoryTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostHistoryTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryTypeRepository.All(limit, offset);

			return this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryTypeResponseModel> Get(int id)
		{
			var record = await this.PostHistoryTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryTypeResponseModel>> Create(
			ApiPostHistoryTypeRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypeResponseModel> response = new CreateResponse<ApiPostHistoryTypeResponseModel>(await this.PostHistoryTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryTypeRepository.Create(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypeResponseModel>> Update(
			int id,
			ApiPostHistoryTypeRequestModel model)
		{
			var validationResult = await this.PostHistoryTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(id, model);
				await this.PostHistoryTypeRepository.Update(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				var record = await this.PostHistoryTypeRepository.Get(id);

				return new UpdateResponse<ApiPostHistoryTypeResponseModel>(this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostHistoryTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostHistoryTypeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostHistoryTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f691e2f14a952420cf38011a7190a25c</Hash>
</Codenesium>*/