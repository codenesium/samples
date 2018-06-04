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
	public abstract class AbstractStudioService: AbstractService
	{
		private IStudioRepository studioRepository;
		private IApiStudioRequestModelValidator studioModelValidator;
		private IBOLStudioMapper BOLStudioMapper;
		private IDALStudioMapper DALStudioMapper;
		private ILogger logger;

		public AbstractStudioService(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolstudioMapper,
			IDALStudioMapper dalstudioMapper)
			: base()

		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
			this.BOLStudioMapper = bolstudioMapper;
			this.DALStudioMapper = dalstudioMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudioResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studioRepository.All(skip, take, orderClause);

			return this.BOLStudioMapper.MapBOToModel(this.DALStudioMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudioResponseModel> Get(int id)
		{
			var record = await studioRepository.Get(id);

			return this.BOLStudioMapper.MapBOToModel(this.DALStudioMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model)
		{
			CreateResponse<ApiStudioResponseModel> response = new CreateResponse<ApiStudioResponseModel>(await this.studioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLStudioMapper.MapModelToBO(default (int), model);
				var record = await this.studioRepository.Create(this.DALStudioMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLStudioMapper.MapBOToModel(this.DALStudioMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudioRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLStudioMapper.MapModelToBO(id, model);
				await this.studioRepository.Update(this.DALStudioMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studioRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5a79ab4949a2a2d5dde1be3a2cac22dc</Hash>
</Codenesium>*/