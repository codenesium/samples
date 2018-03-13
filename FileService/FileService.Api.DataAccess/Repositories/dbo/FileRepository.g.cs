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
	public abstract class AbstractFileRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractFileRepository(ILogger logger,
		                              ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Nullable<int> bucketId,
		                          DateTime dateCreated,
		                          string description,
		                          DateTime expiration,
		                          string extension,
		                          Guid externalId,
		                          decimal fileSizeInBytes,
		                          int fileTypeId,
		                          int id,
		                          string location,
		                          string privateKey,
		                          string publicKey)
		{
			var record = new File ();

			MapPOCOToEF(bucketId,
			            dateCreated,
			            description,
			            expiration,
			            extension,
			            externalId,
			            fileSizeInBytes,
			            fileTypeId,
			            id,
			            location,
			            privateKey,
			            publicKey, record);

			this._context.Set<File>().Add(record);
			this._context.SaveChanges();
			return record.id;
		}

		public virtual void Update(Nullable<int> bucketId,
		                           DateTime dateCreated,
		                           string description,
		                           DateTime expiration,
		                           string extension,
		                           Guid externalId,
		                           decimal fileSizeInBytes,
		                           int fileTypeId,
		                           int id,
		                           string location,
		                           string privateKey,
		                           string publicKey)
		{
			var record =  this.SearchLinqEF(x => x.id == id).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",id);
			}
			else
			{
				MapPOCOToEF(bucketId,
				            dateCreated,
				            description,
				            expiration,
				            extension,
				            externalId,
				            fileSizeInBytes,
				            fileTypeId,
				            id,
				            location,
				            privateKey,
				            publicKey, record);
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
				this._context.Set<File>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int id, Response response)
		{
			this.SearchLinqPOCO(x => x.id == id,response);
		}

		protected virtual List<File> SearchLinqEF(Expression<Func<File, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<File> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<File, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<File, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<File> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<File> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(Nullable<int> bucketId,
		                               DateTime dateCreated,
		                               string description,
		                               DateTime expiration,
		                               string extension,
		                               Guid externalId,
		                               decimal fileSizeInBytes,
		                               int fileTypeId,
		                               int id,
		                               string location,
		                               string privateKey,
		                               string publicKey, File   efFile)
		{
			efFile.bucketId = bucketId;
			efFile.dateCreated = dateCreated;
			efFile.description = description;
			efFile.expiration = expiration;
			efFile.extension = extension;
			efFile.externalId = externalId;
			efFile.fileSizeInBytes = fileSizeInBytes;
			efFile.fileTypeId = fileTypeId;
			efFile.id = id;
			efFile.location = location;
			efFile.privateKey = privateKey;
			efFile.publicKey = publicKey;
		}

		public static void MapEFToPOCO(File efFile,Response response)
		{
			if(efFile == null)
			{
				return;
			}
			response.AddFile(new POCOFile()
			{
				DateCreated = efFile.dateCreated.ToDateTime(),
				Description = efFile.description,
				Expiration = efFile.expiration.ToDateTime(),
				Extension = efFile.extension,
				ExternalId = efFile.externalId,
				FileSizeInBytes = efFile.fileSizeInBytes.ToDecimal(),
				Id = efFile.id.ToInt(),
				Location = efFile.location,
				PrivateKey = efFile.privateKey,
				PublicKey = efFile.publicKey,

				BucketId = new ReferenceEntity<Nullable<int>>(efFile.bucketId,
				                                              "Buckets"),
				FileTypeId = new ReferenceEntity<int>(efFile.fileTypeId,
				                                      "FileTypes"),
			});

			BucketRepository.MapEFToPOCO(efFile.BucketRef, response);

			FileTypeRepository.MapEFToPOCO(efFile.FileTypeRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>69018785d344e54e1edb1b4e868a126a</Hash>
</Codenesium>*/