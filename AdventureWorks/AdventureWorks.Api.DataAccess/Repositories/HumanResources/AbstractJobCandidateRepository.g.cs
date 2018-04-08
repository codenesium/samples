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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractJobCandidateRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Nullable<int> businessEntityID,
		                          string resume,
		                          DateTime modifiedDate)
		{
			var record = new EFJobCandidate ();

			MapPOCOToEF(0, businessEntityID,
			            resume,
			            modifiedDate, record);

			this.context.Set<EFJobCandidate>().Add(record);
			this.context.SaveChanges();
			return record.JobCandidateID;
		}

		public virtual void Update(int jobCandidateID, Nullable<int> businessEntityID,
		                           string resume,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",jobCandidateID);
			}
			else
			{
				MapPOCOToEF(jobCandidateID,  businessEntityID,
				            resume,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int jobCandidateID)
		{
			var record = this.SearchLinqEF(x => x.JobCandidateID == jobCandidateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFJobCandidate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int jobCandidateID, Response response)
		{
			this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID,response);
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

		public virtual List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.JobCandidates;
		}
		public virtual POCOJobCandidate GetByIdDirect(int jobCandidateID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.JobCandidateID == jobCandidateID,response);
			return response.JobCandidates.FirstOrDefault();
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
			efJobCandidate.JobCandidateID = jobCandidateID;
			efJobCandidate.BusinessEntityID = businessEntityID;
			efJobCandidate.Resume = resume;
			efJobCandidate.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFJobCandidate efJobCandidate,Response response)
		{
			if(efJobCandidate == null)
			{
				return;
			}
			response.AddJobCandidate(new POCOJobCandidate()
			{
				JobCandidateID = efJobCandidate.JobCandidateID.ToInt(),
				Resume = efJobCandidate.Resume,
				ModifiedDate = efJobCandidate.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<Nullable<int>>(efJobCandidate.BusinessEntityID,
				                                                      "Employees"),
			});

			EmployeeRepository.MapEFToPOCO(efJobCandidate.Employee, response);
		}
	}
}

/*<Codenesium>
    <Hash>3aab5fa87bd903a810da379369800c46</Hash>
</Codenesium>*/