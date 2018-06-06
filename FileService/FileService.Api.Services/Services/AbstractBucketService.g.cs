using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractBucketService: AbstractService
	{
		private IBucketRepository bucketRepository;
		private IApiBucketRequestModelValidator bucketModelValidator;
		private IBOLBucketMapper bolBucketMapper;
		private IDALBucketMapper dalBucketMapper;
		private ILogger logger;

		public AbstractBucketService(
			ILogger logger,
			IBucketRepository bucketRepository,
			IApiBucketRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bolbucketMapper,
			IDALBucketMapper dalbucketMapper)
			: base()

		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
			this.bolBucketMapper = bolbucketMapper;
			this.dalBucketMapper = dalbucketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBucketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.bucketRepository.All(skip, take, orderClause);

			return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBucketResponseModel> Get(int id)
		{
			var record = await bucketRepository.Get(id);

			return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model)
		{
			CreateResponse<ApiBucketResponseModel> response = new CreateResponse<ApiBucketResponseModel>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolBucketMapper.MapModelToBO(default (int), model);
				var record = await this.bucketRepository.Create(this.dalBucketMapper.MapBOToEF(bo));

				response.SetRecord(this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiBucketRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolBucketMapper.MapModelToBO(id, model);
				await this.bucketRepository.Update(this.dalBucketMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.bucketRepository.Delete(id);
			}
			return response;
		}

		public async Task<ApiBucketResponseModel> GetExternalId(Guid externalId)
		{
			Bucket record = await this.bucketRepository.GetExternalId(externalId);

			return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
		}
		public async Task<ApiBucketResponseModel> GetName(string name)
		{
			Bucket record = await this.bucketRepository.GetName(name);

			return this.bolBucketMapper.MapBOToModel(this.dalBucketMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>c789f9bee45a6ed4b6c6509c3e928c80</Hash>
</Codenesium>*/