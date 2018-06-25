using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBusinessEntityContactRequestModel : AbstractApiRequestModel
        {
                public ApiBusinessEntityContactRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        int personID,
                        Guid rowguid)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                }

                private int contactTypeID;

                [Required]
                public int ContactTypeID
                {
                        get
                        {
                                return this.contactTypeID;
                        }

                        set
                        {
                                this.contactTypeID = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private int personID;

                [Required]
                public int PersonID
                {
                        get
                        {
                                return this.personID;
                        }

                        set
                        {
                                this.personID = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>51b2177737123dc678234c4107aad036</Hash>
</Codenesium>*/