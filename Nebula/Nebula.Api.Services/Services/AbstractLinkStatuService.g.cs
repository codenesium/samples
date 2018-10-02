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
	public abstract class AbstractLinkStatuService : AbstractService
	{
		protected ILinkStatuRepository LinkStatuRepository { get; private set; }

		protected IApiLinkStatuRequestModelValidator LinkStatuModelValidator { get; private set; }

		protected IBOLLinkStatuMapper BolLinkStatuMapper { get; private set; }

		protected IDALLinkStatuMapper DalLinkStatuMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractLinkStatuService(
			ILogger logger,
			ILinkStatuRepository linkStatuRepository,
			IApiLinkStatuRequestModelValidator linkStatuModelValidator,
			IBOLLinkStatuMapper bolLinkStatuMapper,
			IDALLinkStatuMapper dalLinkStatuMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.LinkStatuRepository = linkStatuRepository;
			this.LinkStatuModelValidator = linkStatuModelValidator;
			this.BolLinkStatuMapper = bolLinkStatuMapper;
			this.DalLinkStatuMapper = dalLinkStatuMapper;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkStatuResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LinkStatuRepository.All(limit, offset);

			return this.BolLinkStatuMapper.MapBOToModel(this.DalLinkStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkStatuResponseModel> Get(int id)
		{
			var record = await this.LinkStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkStatuMapper.MapBOToModel(this.DalLinkStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLinkStatuResponseModel>> Create(
			ApiLinkStatuRequestModel model)
		{
			CreateResponse<ApiLinkStatuResponseModel> response = new CreateResponse<ApiLinkStatuResponseModel>(await this.LinkStatuModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLinkStatuMapper.MapModelToBO(default(int), model);
				var record = await this.LinkStatuRepository.Create(this.DalLinkStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLinkStatuMapper.MapBOToModel(this.DalLinkStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLinkStatuResponseModel>> Update(
			int id,
			ApiLinkStatuRequestModel model)
		{
			var validationResult = await this.LinkStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLinkStatuMapper.MapModelToBO(id, model);
				await this.LinkStatuRepository.Update(this.DalLinkStatuMapper.MapBOToEF(bo));

				var record = await this.LinkStatuRepository.Get(id);

				return new UpdateResponse<ApiLinkStatuResponseModel>(this.BolLinkStatuMapper.MapBOToModel(this.DalLinkStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLinkStatuResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.LinkStatuModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LinkStatuRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiLinkStatuResponseModel> ByName(string name)
		{
			LinkStatu record = await this.LinkStatuRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLinkStatuMapper.MapBOToModel(this.DalLinkStatuMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiLinkResponseModel>> Links(int linkStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.LinkStatuRepository.Links(linkStatusId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4139c234864d8624ed8d09b829d3b6a8</Hash>
</Codenesium>*/