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

namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOBucket: AbstractBOManager
	{
		private IBucketRepository bucketRepository;
		private IApiBucketRequestModelValidator bucketModelValidator;
		private IBOLBucketMapper bucketMapper;
		private ILogger logger;

		public AbstractBOBucket(
			ILogger logger,
			IBucketRepository bucketRepository,
			IApiBucketRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bucketMapper)
			: base()

		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
			this.bucketMapper = bucketMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBucketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.bucketRepository.All(skip, take, orderClause);

			return this.bucketMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiBucketResponseModel> Get(int id)
		{
			var record = await bucketRepository.Get(id);

			return this.bucketMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiBucketResponseModel>> Create(
			ApiBucketRequestModel model)
		{
			CreateResponse<ApiBucketResponseModel> response = new CreateResponse<ApiBucketResponseModel>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.bucketMapper.MapModelToDTO(default (int), model);
				var record = await this.bucketRepository.Create(dto);

				response.SetRecord(this.bucketMapper.MapDTOToModel(record));
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
				var dto = this.bucketMapper.MapModelToDTO(id, model);
				await this.bucketRepository.Update(id, dto);
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
			DTOBucket record = await this.bucketRepository.GetExternalId(externalId);

			return this.bucketMapper.MapDTOToModel(record);
		}
		public async Task<ApiBucketResponseModel> GetName(string name)
		{
			DTOBucket record = await this.bucketRepository.GetName(name);

			return this.bucketMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>8dd1337bac4d4ce234d45865fcc41d7a</Hash>
</Codenesium>*/