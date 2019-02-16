import React, { Component } from 'react';
import axios from 'axios';
import {CreateResponse} from '../api/ApiObjects'
import {FormikProps,FormikErrors, Field, withFormik} from 'formik';
import * as Yup from 'yup'
import * as Api from '../api/models';
import Constants from '../constants';
import StudioMapper from '../mapping/studioMapper';
import StudioViewModel from '../viewmodels/studioViewModel';

interface Props {
    model?:StudioViewModel
}


  
   const StudioCreateDisplay: React.SFC<FormikProps<StudioViewModel>> = (props: FormikProps<StudioViewModel>) => {

   let status = props.status as CreateResponse<Api.StudioClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof StudioViewModel]  && props.errors[name as keyof StudioViewModel]) {
            response += props.errors[name as keyof StudioViewModel];
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
                      <label htmlFor="name" className={errorExistForField("address1") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Address1</label>
					<div className="col-sm-12">
                         <Field type="input" name="address1" className ={errorExistForField("address1") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("address1") && <small className="text-danger">{errorsForField("address1")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("address2") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Address2</label>
					<div className="col-sm-12">
                         <Field type="input" name="address2" className ={errorExistForField("address2") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("address2") && <small className="text-danger">{errorsForField("address2")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("city") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>City</label>
					<div className="col-sm-12">
                         <Field type="input" name="city" className ={errorExistForField("city") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("city") && <small className="text-danger">{errorsForField("city")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("isDeleted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
                         <Field type="input" name="isDeleted" className ={errorExistForField("isDeleted") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("isDeleted") && <small className="text-danger">{errorsForField("isDeleted")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					<div className="col-sm-12">
                         <Field type="input" name="name" className ={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("province") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Province</label>
					<div className="col-sm-12">
                         <Field type="input" name="province" className ={errorExistForField("province") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("province") && <small className="text-danger">{errorsForField("province")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("tenantId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
                         <Field type="input" name="tenantId" className ={errorExistForField("tenantId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("tenantId") && <small className="text-danger">{errorsForField("tenantId")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("website") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Website</label>
					<div className="col-sm-12">
                         <Field type="input" name="website" className ={errorExistForField("website") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("website") && <small className="text-danger">{errorsForField("website")}</small>}

                    </div>
                </div>

						<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("zip") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Zip</label>
					<div className="col-sm-12">
                         <Field type="input" name="zip" className ={errorExistForField("zip") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("zip") && <small className="text-danger">{errorsForField("zip")}</small>}

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


const StudioCreateComponent = withFormik<Props, StudioViewModel>({
    mapPropsToValues: props => {
                
		let response = new StudioViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.address1,props.model!.address2,props.model!.city,props.model!.id,props.model!.isDeleted,props.model!.name,props.model!.province,props.model!.tenantId,props.model!.website,props.model!.zip);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<StudioViewModel> = { };

	  if(values.address1 == '') {
                errors.address1 = "Required"
                    }if(values.address2 == '') {
                errors.address2 = "Required"
                    }if(values.city == '') {
                errors.city = "Required"
                    }if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.province == '') {
                errors.province = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }if(values.website == '') {
                errors.website = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new StudioMapper();

        axios.post(Constants.ApiUrl + 'studios',
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.StudioClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as CreateResponse<Api.StudioClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
    },
    displayName: 'StudioCreate', 
  })(StudioCreateDisplay);

  export default StudioCreateComponent;

/*<Codenesium>
    <Hash>c2b010c8332f8f72df90040dfbe820f6</Hash>
</Codenesium>*/