import React, { Component } from 'react';
import axios from 'axios';
import {CreateResponse} from '../api/ApiObjects'
import {FormikProps,FormikErrors, Field, withFormik} from 'formik';
import * as Yup from 'yup'
import * as Api from '../api/models';
import Constants from '../constants';
import SpaceFeatureMapper from '../mapping/spaceFeatureMapper';
import SpaceFeatureViewModel from '../viewmodels/spaceFeatureViewModel';

interface Props {
    model?:SpaceFeatureViewModel
}


  
   const SpaceFeatureCreateDisplay: React.SFC<FormikProps<SpaceFeatureViewModel>> = (props: FormikProps<SpaceFeatureViewModel>) => {

   let status = props.status as CreateResponse<Api.SpaceFeatureClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof SpaceFeatureViewModel]  && props.errors[name as keyof SpaceFeatureViewModel]) {
            response += props.errors[name as keyof SpaceFeatureViewModel];
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
                      <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					<div className="col-sm-12">
                         <Field type="input" name="name" className ={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}

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


const SpaceFeatureCreateComponent = withFormik<Props, SpaceFeatureViewModel>({
    mapPropsToValues: props => {
                
		let response = new SpaceFeatureViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.isDeleted,props.model!.name,props.model!.tenantId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<SpaceFeatureViewModel> = { };

	  if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new SpaceFeatureMapper();

        axios.post(Constants.ApiUrl + 'spacefeatures',
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.SpaceFeatureClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as CreateResponse<Api.SpaceFeatureClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
    },
    displayName: 'SpaceFeatureCreate', 
  })(SpaceFeatureCreateDisplay);

  export default SpaceFeatureCreateComponent;

/*<Codenesium>
    <Hash>d89d1e5058939aa9514408dffdf8a7fa</Hash>
</Codenesium>*/