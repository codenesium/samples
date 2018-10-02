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
	public abstract class AbstractPostLinkService : AbstractService
	{
		protected IPostLinkRepository PostLinkRepository { get; private set; }

		protected IApiPostLinkRequestModelValidator PostLinkModelValidator { get; private set; }

		protected IBOLPostLinkMapper BolPostLinkMapper { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinkService(
			ILogger logger,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkRequestModelValidator postLinkModelValidator,
			IBOLPostLinkMapper bolPostLinkMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base()
		{
			this.PostLinkRepository = postLinkRepository;
			this.PostLinkModelValidator = postLinkModelValidator;
			this.BolPostLinkMapper = bolPostLinkMapper;
			this.DalPostLinkMapper = dalPostLinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPostLinkResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostLinkRepository.All(limit, offset);

			return this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostLinkResponseModel> Get(int id)
		{
			var record = await this.PostLinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostLinkResponseModel>> Create(
			ApiPostLinkRequestModel model)
		{
			CreateResponse<ApiPostLinkResponseModel> response = new CreateResponse<ApiPostLinkResponseModel>(await this.PostLinkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(default(int), model);
				var record = await this.PostLinkRepository.Create(this.DalPostLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinkResponseModel>> Update(
			int id,
			ApiPostLinkRequestModel model)
		{
			var validationResult = await this.PostLinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(id, model);
				await this.PostLinkRepository.Update(this.DalPostLinkMapper.MapBOToEF(bo));

				var record = await this.PostLinkRepository.Get(id);

				return new UpdateResponse<ApiPostLinkResponseModel>(this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPostLinkResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PostLinkModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PostLinkRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a4c6df8a6c734c68116d03f16d62f0c3</Hash>
</Codenesium>*/