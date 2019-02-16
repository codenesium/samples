import React, { Component } from 'react';
import axios from 'axios';
import {CreateResponse} from '../api/ApiObjects'
import {FormikProps,FormikErrors, Field, withFormik} from 'formik';
import * as Yup from 'yup'
import * as Api from '../api/models';
import Constants from '../constants';
import FamilyMapper from '../mapping/familyMapper';
import FamilyViewModel from '../viewmodels/familyViewModel';

interface Props {
    model?:FamilyViewModel
}


  
   const FamilyCreateDisplay: React.SFC<FormikProps<FamilyViewModel>> = (props: FormikProps<FamilyViewModel>) => {

   let status = props.status as CreateResponse<Api.FamilyClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof FamilyViewModel]  && props.errors[name as keyof FamilyViewModel]) {
            response += props.errors[name as keyof FamilyViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("isDeleted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
                         <Field type="input" name="isDeleted" className ={errorExistForField("isDeleted") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("isDeleted") && <small className="text-danger">{errorsForField("isDeleted")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("note") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Note</label>
					<div className="col-sm-12">
                         <Field type="input" name="note" className ={errorExistForField("note") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("note") && <small className="text-danger">{errorsForField("note")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactEmail") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactEmail</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactEmail" className ={errorExistForField("primaryContactEmail") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactEmail") && <small className="text-danger">{errorsForField("primaryContactEmail")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactFirstName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactFirstName</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactFirstName" className ={errorExistForField("primaryContactFirstName") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactFirstName") && <small className="text-danger">{errorsForField("primaryContactFirstName")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactLastName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactLastName</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactLastName" className ={errorExistForField("primaryContactLastName") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactLastName") && <small className="text-danger">{errorsForField("primaryContactLastName")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactPhone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactPhone</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactPhone" className ={errorExistForField("primaryContactPhone") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactPhone") && <small className="text-danger">{errorsForField("primaryContactPhone")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("tenantId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
                         <Field type="input" name="tenantId" className ={errorExistForField("tenantId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("tenantId") && <small className="text-danger">{errorsForField("tenantId")}</small>}

                    </div>
                </div>

			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>);
}


const FamilyCreateComponent = withFormik<Props, FamilyViewModel>({
    mapPropsToValues: props => {
                
		let response = new FamilyViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.isDeleted,props.model!.note,props.model!.primaryContactEmail,props.model!.primaryContactFirstName,props.model!.primaryContactLastName,props.model!.primaryContactPhone,props.model!.tenantId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<FamilyViewModel> = { };

	  if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.primaryContactPhone == '') {
                errors.primaryContactPhone = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new FamilyMapper();

        axios.post(Constants.ApiUrl + 'families',
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.FamilyClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as CreateResponse<Api.FamilyClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
    },
    displayName: 'FamilyCreate', 
  })(FamilyCreateDisplay);

  export default FamilyCreateComponent;

/*<Codenesium>
    <Hash>d402cfe710a528d1d88fee2c3b3e82a2</Hash>
</Codenesium>*/