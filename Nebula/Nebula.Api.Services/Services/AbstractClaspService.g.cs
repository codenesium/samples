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
		private IBOLClaspMapper bolClaspMapper;
		private IDALClaspMapper dalClaspMapper;
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
			this.bolClaspMapper = bolclaspMapper;
			this.dalClaspMapper = dalclaspMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClaspResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.claspRepository.All(skip, take, orderClause);

			return this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClaspResponseModel> Get(int id)
		{
			var record = await claspRepository.Get(id);

			return this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model)
		{
			CreateResponse<ApiClaspResponseModel> response = new CreateResponse<ApiClaspResponseModel>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolClaspMapper.MapModelToBO(default (int), model);
				var record = await this.claspRepository.Create(this.dalClaspMapper.MapBOToEF(bo));

				response.SetRecord(this.bolClaspMapper.MapBOToModel(this.dalClaspMapper.MapEFToBO(record)));
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
				var bo = this.bolClaspMapper.MapModelToBO(id, model);
				await this.claspRepository.Update(this.dalClaspMapper.MapBOToEF(bo));
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
    <Hash>35d9cdab3f81dc93b26eadfdc973fe49</Hash>
</Codenesium>*/