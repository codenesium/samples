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
		private IBOLSpaceMapper BOLSpaceMapper;
		private IDALSpaceMapper DALSpaceMapper;
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
			this.BOLSpaceMapper = bolspaceMapper;
			this.DALSpaceMapper = dalspaceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceRepository.All(skip, take, orderClause);

			return this.BOLSpaceMapper.MapBOToModel(this.DALSpaceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceResponseModel> Get(int id)
		{
			var record = await spaceRepository.Get(id);

			return this.BOLSpaceMapper.MapBOToModel(this.DALSpaceMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model)
		{
			CreateResponse<ApiSpaceResponseModel> response = new CreateResponse<ApiSpaceResponseModel>(await this.spaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSpaceMapper.MapModelToBO(default (int), model);
				var record = await this.spaceRepository.Create(this.DALSpaceMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSpaceMapper.MapBOToModel(this.DALSpaceMapper.MapEFToBO(record)));
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
				var bo = this.BOLSpaceMapper.MapModelToBO(id, model);
				await this.spaceRepository.Update(this.DALSpaceMapper.MapBOToEF(bo));
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
    <Hash>1f1a0b2af4a4c1221d11509c34d3f391</Hash>
</Codenesium>*/