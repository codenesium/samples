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
	public abstract class AbstractClaspService: AbstractService
	{
		private IClaspRepository claspRepository;
		private IApiClaspRequestModelValidator claspModelValidator;
		private IBOLClaspMapper BOLClaspMapper;
		private IDALClaspMapper DALClaspMapper;
		private ILogger logger;

		public AbstractClaspService(
			ILogger logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper bolclaspMapper,
			IDALClaspMapper dalclaspMapper)
			: base()

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.BOLClaspMapper = bolclaspMapper;
			this.DALClaspMapper = dalclaspMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClaspResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.claspRepository.All(skip, take, orderClause);

			return this.BOLClaspMapper.MapBOToModel(this.DALClaspMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClaspResponseModel> Get(int id)
		{
			var record = await claspRepository.Get(id);

			return this.BOLClaspMapper.MapBOToModel(this.DALClaspMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model)
		{
			CreateResponse<ApiClaspResponseModel> response = new CreateResponse<ApiClaspResponseModel>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLClaspMapper.MapModelToBO(default (int), model);
				var record = await this.claspRepository.Create(this.DALClaspMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLClaspMapper.MapBOToModel(this.DALClaspMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClaspRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLClaspMapper.MapModelToBO(id, model);
				await this.claspRepository.Update(this.DALClaspMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.claspRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ec94f315f38ec96d98ac6b8b1f994dec</Hash>
</Codenesium>*/