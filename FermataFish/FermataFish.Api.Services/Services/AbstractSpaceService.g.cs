using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractSpaceService: AbstractService
	{
		private ISpaceRepository spaceRepository;
		private IApiSpaceRequestModelValidator spaceModelValidator;
		private IBOLSpaceMapper bolSpaceMapper;
		private IDALSpaceMapper dalSpaceMapper;
		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolspaceMapper,
			IDALSpaceMapper dalspaceMapper)
			: base()

		{
			this.spaceRepository = spaceRepository;
			this.spaceModelValidator = spaceModelValidator;
			this.bolSpaceMapper = bolspaceMapper;
			this.dalSpaceMapper = dalspaceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceRepository.All(skip, take, orderClause);

			return this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceResponseModel> Get(int id)
		{
			var record = await spaceRepository.Get(id);

			return this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model)
		{
			CreateResponse<ApiSpaceResponseModel> response = new CreateResponse<ApiSpaceResponseModel>(await this.spaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSpaceMapper.MapModelToBO(default (int), model);
				var record = await this.spaceRepository.Create(this.dalSpaceMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSpaceMapper.MapBOToModel(this.dalSpaceMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolSpaceMapper.MapModelToBO(id, model);
				await this.spaceRepository.Update(this.dalSpaceMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.spaceRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>970c610ce41abdf2c683b73f29d05150</Hash>
</Codenesium>*/