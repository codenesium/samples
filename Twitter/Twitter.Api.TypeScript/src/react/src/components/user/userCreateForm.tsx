import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';

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
                        <label htmlFor="name" className={errorExistForField("bioImgUrl") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Bio_img_url</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="bioImgUrl" className={errorExistForField("bioImgUrl") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("bioImgUrl") && <small className="text-danger">{errorsForField("bioImgUrl")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("birthday") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Birthday</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="birthday" className={errorExistForField("birthday") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("birthday") && <small className="text-danger">{errorsForField("birthday")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("contentDescription") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Content_description</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="contentDescription" className={errorExistForField("contentDescription") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("contentDescription") && <small className="text-danger">{errorsForField("contentDescription")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("email") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Email</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="email" className={errorExistForField("email") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("email") && <small className="text-danger">{errorsForField("email")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fullName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Full_name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fullName" className={errorExistForField("fullName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fullName") && <small className="text-danger">{errorsForField("fullName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("headerImgUrl") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Header_img_url</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="headerImgUrl" className={errorExistForField("headerImgUrl") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("headerImgUrl") && <small className="text-danger">{errorsForField("headerImgUrl")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("interest") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Interest</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="interest" className={errorExistForField("interest") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("interest") && <small className="text-danger">{errorsForField("interest")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("locationLocationId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Location_location_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="locationLocationId" className={errorExistForField("locationLocationId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("locationLocationId") && <small className="text-danger">{errorsForField("locationLocationId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("password") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Password</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="password" className={errorExistForField("password") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("password") && <small className="text-danger">{errorsForField("password")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("phoneNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Phone_number</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="phoneNumber" className={errorExistForField("phoneNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("phoneNumber") && <small className="text-danger">{errorsForField("phoneNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("privacy") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Privacy</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="privacy" className={errorExistForField("privacy") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("privacy") && <small className="text-danger">{errorsForField("privacy")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("username") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Username</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="username" className={errorExistForField("username") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("username") && <small className="text-danger">{errorsForField("username")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("website") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Website</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="website" className={errorExistForField("website") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("website") && <small className="text-danger">{errorsForField("website")}</small>}
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


const UserCreate = withFormik<Props, UserViewModel>({
    mapPropsToValues: props => {
                
		let response = new UserViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.bioImgUrl,props.model!.birthday,props.model!.contentDescription,props.model!.email,props.model!.fullName,props.model!.headerImgUrl,props.model!.interest,props.model!.locationLocationId,props.model!.password,props.model!.phoneNumber,props.model!.privacy,props.model!.userId,props.model!.username,props.model!.website);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<UserViewModel> = { };

	  if(values.email == '') {
                errors.email = "Required"
                    }if(values.fullName == '') {
                errors.fullName = "Required"
                    }if(values.locationLocationId == 0) {
                errors.locationLocationId = "Required"
                    }if(values.password == '') {
                errors.password = "Required"
                    }if(values.privacy == '') {
                errors.privacy = "Required"
                    }if(values.username == '') {
                errors.username = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new UserMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Users,
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
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'UserCreate', 
  })(UserCreateDisplay);

  interface UserCreateComponentProps
  {
  }

  interface UserCreateComponentState
  {
      model?:UserViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class UserCreateComponent extends React.Component<UserCreateComponentProps, UserCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<UserCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>6330c28e99b4b1bd3500680046e8a5b4</Hash>
</Codenesium>*/