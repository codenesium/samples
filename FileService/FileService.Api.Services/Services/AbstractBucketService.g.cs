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
		private IBOLBucketMapper BOLBucketMapper;
		private IDALBucketMapper DALBucketMapper;
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
			this.BOLBucketMapper = bolbucketMapper;
			this.DALBucketMapper = dalbucketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBucketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.bucketRepository.All(skip, take, orderClause);

			return this.BOLBucketMapper.MapBOToModel(this.DALBucketMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBucketResponseModel> Get(int id)
		{
			var record = await bucketRepository.Get(id);

			return this.BOLBucketMapper.MapBOToModel(this.DALBucketMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model)
		{
			CreateResponse<ApiBucketResponseModel> response = new CreateResponse<ApiBucketResponseModel>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLBucketMapper.MapModelToBO(default (int), model);
				var record = await this.bucketRepository.Create(this.DALBucketMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLBucketMapper.MapBOToModel(this.DALBucketMapper.MapEFToBO(record)));
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
				var bo = this.BOLBucketMapper.MapModelToBO(id, model);
				await this.bucketRepository.Update(this.DALBucketMapper.MapBOToEF(bo));
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

			return this.BOLBucketMapper.MapBOToModel(this.DALBucketMapper.MapEFToBO(record));
		}
		public async Task<ApiBucketResponseModel> GetName(string name)
		{
			Bucket record = await this.bucketRepository.GetName(name);

			return this.BOLBucketMapper.MapBOToModel(this.DALBucketMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>64b9d97dd8b7afd1eb75e2c5b63013e6</Hash>
</Codenesium>*/