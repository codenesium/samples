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
	public abstract class AbstractBOBucket
	{
		private IBucketRepository bucketRepository;
		private IApiBucketModelValidator bucketModelValidator;
		private ILogger logger;

		public AbstractBOBucket(
			ILogger logger,
			IBucketRepository bucketRepository,
			IApiBucketModelValidator bucketModelValidator)

		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBucket> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.bucketRepository.All(skip, take, orderClause);
		}

		public virtual POCOBucket Get(int id)
		{
			return this.bucketRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOBucket>> Create(
			ApiBucketModel model)
		{
			CreateResponse<POCOBucket> response = new CreateResponse<POCOBucket>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBucket record = this.bucketRepository.Create(model);
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
				this.bucketRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.bucketModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.bucketRepository.Delete(id);
			}
			return response;
		}

		public POCOBucket Name(string name)
		{
			return this.bucketRepository.Name(name);
		}

		public POCOBucket ExternalId(Guid externalId)
		{
			return this.bucketRepository.ExternalId(externalId);
		}
	}
}

/*<Codenesium>
    <Hash>a56dec3ca36e96aea4590871e1f8944f</Hash>
</Codenesium>*/