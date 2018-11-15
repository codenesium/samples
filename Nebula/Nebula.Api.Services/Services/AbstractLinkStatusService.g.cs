using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractLinkStatusService : AbstractService
	{
		protected ILinkStatusRepository LinkStatusRepository { get; private set; }

		protected IApiLinkStatusServerRequestModelValidator LinkStatusModelValidator { get; private set; }

		protected IBOLLinkStatusMapper BolLinkStatusMapper { get; private set; }

		protected IDALLinkStatusMapper DalLinkStatusMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkStatusService(
			ILogger logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusServerRequestModelValidator linkStatusModelValidator,
			IBOLLinkStatusMapper bolLinkStatusMapper,
			IDALLinkStatusMapper dalLinkStatusMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.LinkStatusRepository = linkStatusRepository;
			this.LinkStatusModelValidator = linkStatusModelValidator;
			this.BolLinkStatusMapper = bolLinkStatusMapper;
			this.DalLinkStatusMapper = dalLinkStatusMapper;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkStatusRepository.All(limit, offset);

			return this.BolLinkStatusMapper.MapBOToModel(this.DalLinkStatusMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkStatusServerResponseModel> Get(int id)
		{
			var record = await this.LinkStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkStatusMapper.MapBOToModel(this.DalLinkStatusMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkStatusServerResponseModel>> Create(
			ApiLinkStatusServerRequestModel model)
		{
			CreateResponse<ApiLinkStatusServerResponseModel> response = ValidationResponseFactory<ApiLinkStatusServerResponseModel>.CreateResponse(await this.LinkStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLinkStatusMapper.MapModelToBO(default(int), model);
				var record = await this.LinkStatusRepository.Create(this.DalLinkStatusMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkStatusMapper.MapBOToModel(this.DalLinkStatusMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkStatusServerResponseModel>> Update(
			int id,
			ApiLinkStatusServerRequestModel model)
		{
			var validationResult = await this.LinkStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkStatusMapper.MapModelToBO(id, model);
				await this.LinkStatusRepository.Update(this.DalLinkStatusMapper.MapBOToEF(bo));

				var record = await this.LinkStatusRepository.Get(id);

				return ValidationResponseFactory<ApiLinkStatusServerResponseModel>.UpdateResponse(this.BolLinkStatusMapper.MapBOToModel(this.DalLinkStatusMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiLinkStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LinkStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.LinkStatusRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<ApiLinkStatusServerResponseModel> ByName(string name)
		{
			LinkStatus record = await this.LinkStatusRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkStatusMapper.MapBOToModel(this.DalLinkStatusMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> LinksByLinkStatusId(int linkStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.LinkStatusRepository.LinksByLinkStatusId(linkStatusId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>63a00e2a8dcae8196b3c05e8b3378c8c</Hash>
</Codenesium>*/