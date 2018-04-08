using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractBucketRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractBucketRepository(ILogger logger,
		                                ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          Guid externalId)
		{
			var record = new EFBucket ();

			MapPOCOToEF(0, name,
			            externalId, record);

			this.context.Set<EFBucket>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(int id, string name,
		                           Guid externalId)
		{
			var record =  this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(id,  name,
				            externalId, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFBucket>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.Id == id,response);
		}

		protected virtual List<EFBucket> SearchLinqEF(Expression<Func<EFBucket, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBucket> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBucket, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOBucket> GetWhereDirect(Expression<Func<EFBucket, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Buckets;
		}
		public virtual POCOBucket GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id,response);
			return response.Buckets.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFBucket, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBucket> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBucket> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int id, string name,
		                               Guid externalId, EFBucket   efBucket)
		{
			efBucket.Id = id;
			efBucket.Name = name;
			efBucket.ExternalId = externalId;
		}

		public static void MapEFToPOCO(EFBucket efBucket,Response response)
		{
			if(efBucket == null)
			{
				return;
			}
			response.AddBucket(new POCOBucket()
			{
				Id = efBucket.Id.ToInt(),
				Name = efBucket.Name,
				ExternalId = efBucket.ExternalId,
			});
		}
	}
}

/*<Codenesium>
    <Hash>057b45bde41e6f68e83bdda22cddb1c3</Hash>
</Codenesium>*/