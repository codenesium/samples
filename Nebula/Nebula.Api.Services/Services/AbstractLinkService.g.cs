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
	public abstract class AbstractLinkService: AbstractService
	{
		private ILinkRepository linkRepository;
		private IApiLinkRequestModelValidator linkModelValidator;
		private IBOLLinkMapper bolLinkMapper;
		private IDALLinkMapper dalLinkMapper;
		private ILogger logger;

		public AbstractLinkService(
			ILogger logger,
			ILinkRepository linkRepository,
			IApiLinkRequestModelValidator linkModelValidator,
			IBOLLinkMapper bollinkMapper,
			IDALLinkMapper dallinkMapper)
			: base()

		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
			this.bolLinkMapper = bollinkMapper;
			this.dalLinkMapper = dallinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkRepository.All(skip, take, orderClause);

			return this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkResponseModel> Get(int id)
		{
			var record = await linkRepository.Get(id);

			return this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model)
		{
			CreateResponse<ApiLinkResponseModel> response = new CreateResponse<ApiLinkResponseModel>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolLinkMapper.MapModelToBO(default (int), model);
				var record = await this.linkRepository.Create(this.dalLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.bolLinkMapper.MapBOToModel(this.dalLinkMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolLinkMapper.MapModelToBO(id, model);
				await this.linkRepository.Update(this.dalLinkMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6b4e25ba2bc7247f5e39ed9c17c90acc</Hash>
</Codenesium>*/