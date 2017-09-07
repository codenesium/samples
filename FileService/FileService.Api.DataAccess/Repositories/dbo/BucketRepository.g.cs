using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractBucketRepository
	{
		protected DbContext _context;
		protected ILogger _logger;

		public AbstractBucketRepository(ILogger logger,
		                                DbContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Guid externalId,
		                          int id,
		                          string name)
		{
			var record = new Bucket ();

			MapPOCOToEF(externalId,
			            id,
			            name, record);

			this._context.Set<Bucket>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(Guid externalId,
		                           int id,
		                           string name)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.Error("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(externalId,
				            id,
				            name, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int id)
		{
			var record = this.SearchLinqEF(x => x.id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<Bucket>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<Bucket> SearchLinqEF(Expression<Func<Bucket, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<Bucket> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<Bucket, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<Bucket, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Bucket> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<Bucket> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(Guid externalId,
		                               int id,
		                               string name, Bucket   efBucket)
		{
			efBucket.externalId = externalId;
			efBucket.id = id;
			efBucket.name = name;
		}

		public static void MapEFToPOCO(Bucket efBucket,Response response)
		{
			if(efBucket == null)
			{
				return;
			}
			response.AddBucket(new POCOBucket()
			{
				ExternalId = efBucket.externalId,
				Id = efBucket.id.ToInt(),
				Name = efBucket.name,
			});
		}
	}
}

/*<Codenesium>
    <Hash>46ad8b9b018c0c26ef6cedcb8b57131c</Hash>
</Codenesium>*/