using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBusinessEntityService: AbstractService
	{
		private IBusinessEntityRepository businessEntityRepository;
		private IApiBusinessEntityRequestModelValidator businessEntityModelValidator;
		private IBOLBusinessEntityMapper bolBusinessEntityMapper;
		private IDALBusinessEntityMapper dalBusinessEntityMapper;
		private ILogger logger;

		public AbstractBusinessEntityService(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityRequestModelValidator businessEntityModelValidator,
			IBOLBusinessEntityMapper bolbusinessEntityMapper,
			IDALBusinessEntityMapper dalbusinessEntityMapper)
			: base()

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.bolBusinessEntityMapper = bolbusinessEntityMapper;
			this.dalBusinessEntityMapper = dalbusinessEntityMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.businessEntityRepository.All(skip, take, orderClause);

			return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityResponseModel> Get(int businessEntityID)
		{
			var record = await businessEntityRepository.Get(businessEntityID);

			return this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityResponseModel>> Create(
			ApiBusinessEntityRequestModel model)
		{
			CreateResponse<ApiBusinessEntityResponseModel> response = new CreateResponse<ApiBusinessEntityResponseModel>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolBusinessEntityMapper.MapModelToBO(default (int), model);
				var record = await this.businessEntityRepository.Create(this.dalBusinessEntityMapper.MapBOToEF(bo));

				response.SetRecord(this.bolBusinessEntityMapper.MapBOToModel(this.dalBusinessEntityMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.bolBusinessEntityMapper.MapModelToBO(businessEntityID, model);
				await this.businessEntityRepository.Update(this.dalBusinessEntityMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0a7c6d471815f4bd113ea67146057b77</Hash>
</Codenesium>*/