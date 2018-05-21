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
		private IApiBucketModelValidator bucketModelValidator;
		private ILogger logger;

		public AbstractBOBucket(
			ILogger logger,
			IBucketRepository bucketRepository,
			IApiBucketModelValidator bucketModelValidator)
			: base()

		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOBucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.bucketRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOBucket> Get(int id)
		{
			return this.bucketRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOBucket>> Create(
			ApiBucketModel model)
		{
			CreateResponse<POCOBucket> response = new CreateResponse<POCOBucket>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBucket record = await this.bucketRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiBucketModel model)
		{
			ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.bucketRepository.Update(id, model);
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

		public async Task<POCOBucket> Name(string name)
		{
			return await this.bucketRepository.Name(name);
		}
		public async Task<POCOBucket> ExternalId(Guid externalId)
		{
			return await this.bucketRepository.ExternalId(externalId);
		}
	}
}

/*<Codenesium>
    <Hash>bcad9eeea57b329569f627f9a5b3135d</Hash>
</Codenesium>*/