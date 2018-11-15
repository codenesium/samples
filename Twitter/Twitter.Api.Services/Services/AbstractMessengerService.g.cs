using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractMessengerService : AbstractService
	{
		protected IMessengerRepository MessengerRepository { get; private set; }

		protected IApiMessengerServerRequestModelValidator MessengerModelValidator { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessengerService(
			ILogger logger,
			IMessengerRepository messengerRepository,
			IApiMessengerServerRequestModelValidator messengerModelValidator,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base()
		{
			this.MessengerRepository = messengerRepository;
			this.MessengerModelValidator = messengerModelValidator;
			this.BolMessengerMapper = bolMessengerMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiMessengerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MessengerRepository.All(limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMessengerServerResponseModel> Get(int id)
		{
			var record = await this.MessengerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMessengerServerResponseModel>> Create(
			ApiMessengerServerRequestModel model)
		{
			CreateResponse<ApiMessengerServerResponseModel> response = ValidationResponseFactory<ApiMessengerServerResponseModel>.CreateResponse(await this.MessengerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolMessengerMapper.MapModelToBO(default(int), model);
				var record = await this.MessengerRepository.Create(this.DalMessengerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMessengerServerResponseModel>> Update(
			int id,
			ApiMessengerServerRequestModel model)
		{
			var validationResult = await this.MessengerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMessengerMapper.MapModelToBO(id, model);
				await this.MessengerRepository.Update(this.DalMessengerMapper.MapBOToEF(bo));

				var record = await this.MessengerRepository.Get(id);

				return ValidationResponseFactory<ApiMessengerServerResponseModel>.UpdateResponse(this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiMessengerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.MessengerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.MessengerRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByMessageId(int? messageId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByMessageId(messageId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByToUserId(int toUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByToUserId(toUserId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByUserId(userId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>763a587cad1a75c9dbe8f6fa6d5d9b4c</Hash>
</Codenesium>*/