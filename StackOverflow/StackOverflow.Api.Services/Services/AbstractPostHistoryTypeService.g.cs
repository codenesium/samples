using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryTypeService : AbstractService
	{
		protected IPostHistoryTypeRepository PostHistoryTypeRepository { get; private set; }

		protected IApiPostHistoryTypeServerRequestModelValidator PostHistoryTypeModelValidator { get; private set; }

		protected IBOLPostHistoryTypeMapper BolPostHistoryTypeMapper { get; private set; }

		protected IDALPostHistoryTypeMapper DalPostHistoryTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryTypeService(
			ILogger logger,
			IPostHistoryTypeRepository postHistoryTypeRepository,
			IApiPostHistoryTypeServerRequestModelValidator postHistoryTypeModelValidator,
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

		public virtual async Task<List<ApiPostHistoryTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryTypeRepository.All(limit, offset);

			return this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryTypeServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPostHistoryTypeServerResponseModel>> Create(
			ApiPostHistoryTypeServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryTypeServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.CreateResponse(await this.PostHistoryTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryTypeRepository.Create(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryTypeServerResponseModel>> Update(
			int id,
			ApiPostHistoryTypeServerRequestModel model)
		{
			var validationResult = await this.PostHistoryTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostHistoryTypeMapper.MapModelToBO(id, model);
				await this.PostHistoryTypeRepository.Update(this.DalPostHistoryTypeMapper.MapBOToEF(bo));

				var record = await this.PostHistoryTypeRepository.Get(id);

				return ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.UpdateResponse(this.BolPostHistoryTypeMapper.MapBOToModel(this.DalPostHistoryTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPostHistoryTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostHistoryTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostHistoryTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cc7a0dc71773c920188e17a29087f787</Hash>
</Codenesium>*/