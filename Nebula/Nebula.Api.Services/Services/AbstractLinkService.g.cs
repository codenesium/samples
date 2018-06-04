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
		private IBOLLinkMapper BOLLinkMapper;
		private IDALLinkMapper DALLinkMapper;
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
			this.BOLLinkMapper = bollinkMapper;
			this.DALLinkMapper = dallinkMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLinkResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.linkRepository.All(skip, take, orderClause);

			return this.BOLLinkMapper.MapBOToModel(this.DALLinkMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLinkResponseModel> Get(int id)
		{
			var record = await linkRepository.Get(id);

			return this.BOLLinkMapper.MapBOToModel(this.DALLinkMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model)
		{
			CreateResponse<ApiLinkResponseModel> response = new CreateResponse<ApiLinkResponseModel>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLLinkMapper.MapModelToBO(default (int), model);
				var record = await this.linkRepository.Create(this.DALLinkMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLLinkMapper.MapBOToModel(this.DALLinkMapper.MapEFToBO(record)));
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
				var bo = this.BOLLinkMapper.MapModelToBO(id, model);
				await this.linkRepository.Update(this.DALLinkMapper.MapBOToEF(bo));
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
    <Hash>7d4de429739eb66eaae95ff9325827b0</Hash>
</Codenesium>*/