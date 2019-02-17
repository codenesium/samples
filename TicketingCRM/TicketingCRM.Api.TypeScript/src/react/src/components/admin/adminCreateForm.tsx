import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import AdminMapper from './adminMapper';
import AdminViewModel from './adminViewModel';

interface Props {
    model?:AdminViewModel
}

   const AdminCreateDisplay: React.SFC<FormikProps<AdminViewModel>> = (props: FormikProps<AdminViewModel>) => {

   let status = props.status as CreateResponse<Api.AdminClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof AdminViewModel]  && props.errors[name as keyof AdminViewModel]) {
            response += props.errors[name as keyof AdminViewModel];
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
                        <label htmlFor="name" className={errorExistForField("email") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Email</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="email" className={errorExistForField("email") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("email") && <small className="text-danger">{errorsForField("email")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("firstName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FirstName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="firstName" className={errorExistForField("firstName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("firstName") && <small className="text-danger">{errorsForField("firstName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="lastName" className={errorExistForField("lastName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastName") && <small className="text-danger">{errorsForField("lastName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("password") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Password</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="password" className={errorExistForField("password") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("password") && <small className="text-danger">{errorsForField("password")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("phone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Phone</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="phone" className={errorExistForField("phone") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("phone") && <small className="text-danger">{errorsForField("phone")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("username") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Username</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="username" className={errorExistForField("username") ? "form-control is-invalid" : "form-control"} />
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


const AdminCreate = withFormik<Props, AdminViewModel>({
    mapPropsToValues: props => {
                
		let response = new AdminViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.email,props.model!.firstName,props.model!.id,props.model!.lastName,props.model!.password,props.model!.phone,props.model!.username);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<AdminViewModel> = { };

	  if(values.email == '') {
                errors.email = "Required"
                    }if(values.firstName == '') {
                errors.firstName = "Required"
                    }if(values.lastName == '') {
                errors.lastName = "Required"
                    }if(values.password == '') {
                errors.password = "Required"
                    }if(values.phone == '') {
                errors.phone = "Required"
                    }if(values.username == '') {
                errors.username = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new AdminMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Admins,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.AdminClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'AdminCreate', 
  })(AdminCreateDisplay);

  interface AdminCreateComponentProps
  {
  }

  interface AdminCreateComponentState
  {
      model?:AdminViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AdminCreateComponent extends React.Component<AdminCreateComponentProps, AdminCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<AdminCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>4688900a6e3c206373bb910a785c7506</Hash>
</Codenesium>*/