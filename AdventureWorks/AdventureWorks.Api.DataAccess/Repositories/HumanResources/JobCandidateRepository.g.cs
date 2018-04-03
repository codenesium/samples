using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractJobCandidateRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractJobCandidateRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Nullable<int> businessEntityID,
		                          string resume,
		                          DateTime modifiedDate)
		{
			var record = new EFJobCandidate ();

			MapPOCOToEF(0, businessEntityID,
			            resume,
			            modifiedDate, record);

			this._context.Set<EFJobCandidate>().Add(record);
			this._context.SaveChanges();
			return record.jobCandidateID;
		}

		public virtual void Update(int jobCandidateID, Nullable<int> businessEntityID,
		                           string resume,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.jobCandidateID == jobCandidateID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",jobCandidateID);
			}
			else
			{
				MapPOCOToEF(jobCandidateID,  businessEntityID,
				            resume,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int jobCandidateID)
		{
			var record = this.SearchLinqEF(x => x.jobCandidateID == jobCandidateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFJobCandidate>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int jobCandidateID, Response response)
		{
			this.SearchLinqPOCO(x => x.jobCandidateID == jobCandidateID,response);
		}

		protected virtual List<EFJobCandidate> SearchLinqEF(Expression<Func<EFJobCandidate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFJobCandidate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFJobCandidate, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFJobCandidate> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFJobCandidate> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int jobCandidateID, Nullable<int> businessEntityID,
		                               string resume,
		                               DateTime modifiedDate, EFJobCandidate   efJobCandidate)
		{
			efJobCandidate.jobCandidateID = jobCandidateID;
			efJobCandidate.businessEntityID = businessEntityID;
			efJobCandidate.resume = resume;
			efJobCandidate.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFJobCandidate efJobCandidate,Response response)
		{
			if(efJobCandidate == null)
			{
				return;
			}
			response.AddJobCandidate(new POCOJobCandidate()
			{
				JobCandidateID = efJobCandidate.jobCandidateID.ToInt(),
				BusinessEntityID = efJobCandidate.businessEntityID.ToNullableInt(),
				Resume = efJobCandidate.resume,
				ModifiedDate = efJobCandidate.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>1338f2df616d2f1e1d969dc453259fec</Hash>
</Codenesium>*/