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
		private IBucketModelValidator bucketModelValidator;
		private ILogger logger;

		public AbstractBOBucket(
			ILogger logger,
			IBucketRepository bucketRepository,
			IBucketModelValidator bucketModelValidator)

		{
			this.bucketRepository = bucketRepository;
			this.bucketModelValidator = bucketModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BucketModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.bucketModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.bucketRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			BucketModel model)
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

		public virtual ApiResponse GetById(int id)
		{
			return this.bucketRepository.GetById(id);
		}

		public virtual POCOBucket GetByIdDirect(int id)
		{
			return this.bucketRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.bucketRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.bucketRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.bucketRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6729f2f48772e6344df270cd27ccd558</Hash>
</Codenesium>*/