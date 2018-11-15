using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostLinkService : AbstractService
	{
		protected IPostLinkRepository PostLinkRepository { get; private set; }

		protected IApiPostLinkServerRequestModelValidator PostLinkModelValidator { get; private set; }

		protected IBOLPostLinkMapper BolPostLinkMapper { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinkService(
			ILogger logger,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkServerRequestModelValidator postLinkModelValidator,
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

		public virtual async Task<List<ApiPostLinkServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostLinkRepository.All(limit, offset);

			return this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostLinkServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiPostLinkServerResponseModel>> Create(
			ApiPostLinkServerRequestModel model)
		{
			CreateResponse<ApiPostLinkServerResponseModel> response = ValidationResponseFactory<ApiPostLinkServerResponseModel>.CreateResponse(await this.PostLinkModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(default(int), model);
				var record = await this.PostLinkRepository.Create(this.DalPostLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinkServerResponseModel>> Update(
			int id,
			ApiPostLinkServerRequestModel model)
		{
			var validationResult = await this.PostLinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPostLinkMapper.MapModelToBO(id, model);
				await this.PostLinkRepository.Update(this.DalPostLinkMapper.MapBOToEF(bo));

				var record = await this.PostLinkRepository.Get(id);

				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(this.BolPostLinkMapper.MapBOToModel(this.DalPostLinkMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostLinkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostLinkRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>62c187046c4254f55b859bb4ba3cdeb7</Hash>
</Codenesium>*/