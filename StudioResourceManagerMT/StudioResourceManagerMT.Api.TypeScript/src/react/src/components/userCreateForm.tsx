import React, { Component } from 'react';
import axios from 'axios';
import {CreateResponse} from '../api/ApiObjects'
import {FormikProps,FormikErrors, Field, withFormik} from 'formik';
import * as Yup from 'yup'
import * as Api from '../api/models';
import Constants from '../constants';
import UserMapper from '../mapping/userMapper';
import UserViewModel from '../viewmodels/userViewModel';

interface Props {
    model?:UserViewModel
}


  
   const UserCreateDisplay: React.SFC<FormikProps<UserViewModel>> = (props: FormikProps<UserViewModel>) => {

   let status = props.status as CreateResponse<Api.UserClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof UserViewModel]  && props.errors[name as keyof UserViewModel]) {
            response += props.errors[name as keyof UserViewModel];
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
                      <label htmlFor="name" className={errorExistForField("password") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Password</label>
					<div className="col-sm-12">
                         <Field type="input" name="password" className ={errorExistForField("password") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("password") && <small className="text-danger">{errorsForField("password")}</small>}

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
                      <label htmlFor="name" className={errorExistForField("username") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Username</label>
					<div className="col-sm-12">
                         <Field type="input" name="username" className ={errorExistForField("username") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("username") && <small className="text-danger">{errorsForField("username")}</small>}

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


const UserCreateComponent = withFormik<Props, UserViewModel>({
    mapPropsToValues: props => {
                
		let response = new UserViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.isDeleted,props.model!.password,props.model!.tenantId,props.model!.username);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<UserViewModel> = { };

	  if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.password == '') {
                errors.password = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }if(values.username == '') {
                errors.username = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new UserMapper();

        axios.post(Constants.ApiUrl + 'users',
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.UserClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as CreateResponse<Api.UserClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
    },
    displayName: 'UserCreate', 
  })(UserCreateDisplay);

  export default UserCreateComponent;

/*<Codenesium>
    <Hash>9b5f6eec94f35237917c8b30c5271ac2</Hash>
</Codenesium>*/