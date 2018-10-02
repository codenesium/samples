using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractMessengerService : AbstractService
	{
		protected IMessengerRepository MessengerRepository { get; private set; }

		protected IApiMessengerRequestModelValidator MessengerModelValidator { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessengerService(
			ILogger logger,
			IMessengerRepository messengerRepository,
			IApiMessengerRequestModelValidator messengerModelValidator,
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

		public virtual async Task<List<ApiMessengerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MessengerRepository.All(limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMessengerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiMessengerResponseModel>> Create(
			ApiMessengerRequestModel model)
		{
			CreateResponse<ApiMessengerResponseModel> response = new CreateResponse<ApiMessengerResponseModel>(await this.MessengerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMessengerMapper.MapModelToBO(default(int), model);
				var record = await this.MessengerRepository.Create(this.DalMessengerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMessengerResponseModel>> Update(
			int id,
			ApiMessengerRequestModel model)
		{
			var validationResult = await this.MessengerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMessengerMapper.MapModelToBO(id, model);
				await this.MessengerRepository.Update(this.DalMessengerMapper.MapBOToEF(bo));

				var record = await this.MessengerRepository.Get(id);

				return new UpdateResponse<ApiMessengerResponseModel>(this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMessengerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.MessengerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MessengerRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiMessengerResponseModel>> ByMessageId(int? messageId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByMessageId(messageId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async Task<List<ApiMessengerResponseModel>> ByToUserId(int toUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByToUserId(toUserId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async Task<List<ApiMessengerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByUserId(userId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3a65c0037dc774da7deb844aaca8dac8</Hash>
</Codenesium>*/