using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DocumentModel
	{
		public DocumentModel()
		{}

		public DocumentModel(Nullable<short> documentLevel,
		                     string title,
		                     int owner,
		                     bool folderFlag,
		                     string fileName,
		                     string fileExtension,
		                     string revision,
		                     int changeNumber,
		                     int status,
		                     string documentSummary,
		                     byte[] document1,
		                     Guid rowguid,
		                     DateTime modifiedDate)
		{
			this.DocumentLevel = documentLevel;
			this.Title = title;
			this.Owner = owner.ToInt();
			this.FolderFlag = folderFlag;
			this.FileName = fileName;
			this.FileExtension = fileExtension;
			this.Revision = revision;
			this.ChangeNumber = changeNumber.ToInt();
			this.Status = status;
			this.DocumentSummary = documentSummary;
			this.Document1 = document1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public DocumentModel(POCODocument poco)
		{
			this.DocumentLevel = poco.DocumentLevel;
			this.Title = poco.Title;
			this.FolderFlag = poco.FolderFlag;
			this.FileName = poco.FileName;
			this.FileExtension = poco.FileExtension;
			this.Revision = poco.Revision;
			this.ChangeNumber = poco.ChangeNumber.ToInt();
			this.Status = poco.Status;
			this.DocumentSummary = poco.DocumentSummary;
			this.Document1 = poco.Document1;
			this.Rowguid = poco.Rowguid;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.Owner = poco.Owner.Value.ToInt();
		}

		private Nullable<short> _documentLevel;
		public Nullable<short> DocumentLevel
		{
			get
			{
				return _documentLevel.IsEmptyOrZeroOrNull() ? null : _documentLevel;
			}
			set
			{
				this._documentLevel = value;
			}
		}

		private string _title;
		[Required]
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				this._title = value;
			}
		}

		private int _owner;
		[Required]
		public int Owner
		{
			get
			{
				return _owner;
			}
			set
			{
				this._owner = value;
			}
		}

		private bool _folderFlag;
		[Required]
		public bool FolderFlag
		{
			get
			{
				return _folderFlag;
			}
			set
			{
				this._folderFlag = value;
			}
		}

		private string _fileName;
		[Required]
		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				this._fileName = value;
			}
		}

		private string _fileExtension;
		[Required]
		public string FileExtension
		{
			get
			{
				return _fileExtension;
			}
			set
			{
				this._fileExtension = value;
			}
		}

		private string _revision;
		[Required]
		public string Revision
		{
			get
			{
				return _revision;
			}
			set
			{
				this._revision = value;
			}
		}

		private int _changeNumber;
		[Required]
		public int ChangeNumber
		{
			get
			{
				return _changeNumber;
			}
			set
			{
				this._changeNumber = value;
			}
		}

		private int _status;
		[Required]
		public int Status
		{
			get
			{
				return _status;
			}
			set
			{
				this._status = value;
			}
		}

		private string _documentSummary;
		public string DocumentSummary
		{
			get
			{
				return _documentSummary.IsEmptyOrZeroOrNull() ? null : _documentSummary;
			}
			set
			{
				this._documentSummary = value;
			}
		}

		private byte[] _document1;
		public byte[] Document1
		{
			get
			{
				return _document1.IsEmptyOrZeroOrNull() ? null : _document1;
			}
			set
			{
				this._document1 = value;
			}
		}

		private Guid _rowguid;
		[Required]
		public Guid Rowguid
		{
			get
			{
				return _rowguid;
			}
			set
			{
				this._rowguid = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>eb85e1823f928db0b5717e7eda267b5e</Hash>
</Codenesium>*/