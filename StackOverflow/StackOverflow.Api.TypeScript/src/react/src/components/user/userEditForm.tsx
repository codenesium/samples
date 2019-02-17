import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import UserViewModel from './userViewModel';
import UserMapper from './userMapper';

interface Props {
    model?:UserViewModel
}

  const UserEditDisplay = (props: FormikProps<UserViewModel>) => {

   let status = props.status as UpdateResponse<Api.UserClientRequestModel>;
   
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("aboutMe") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AboutMe</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="aboutMe" className={errorExistForField("aboutMe") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("aboutMe") && <small className="text-danger">{errorsForField("aboutMe")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("accountId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AccountId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="accountId" className={errorExistForField("accountId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("accountId") && <small className="text-danger">{errorsForField("accountId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("age") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Age</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="age" className={errorExistForField("age") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("age") && <small className="text-danger">{errorsForField("age")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creationDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreationDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="creationDate" className={errorExistForField("creationDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creationDate") && <small className="text-danger">{errorsForField("creationDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("displayName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DisplayName</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="displayName" className={errorExistForField("displayName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("displayName") && <small className="text-danger">{errorsForField("displayName")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("downVote") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DownVotes</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="downVote" className={errorExistForField("downVote") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("downVote") && <small className="text-danger">{errorsForField("downVote")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("emailHash") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EmailHash</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="emailHash" className={errorExistForField("emailHash") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("emailHash") && <small className="text-danger">{errorsForField("emailHash")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("lastAccessDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>LastAccessDate</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="lastAccessDate" className={errorExistForField("lastAccessDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("lastAccessDate") && <small className="text-danger">{errorsForField("lastAccessDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("location") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Location</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="location" className={errorExistForField("location") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("location") && <small className="text-danger">{errorsForField("location")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("reputation") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Reputation</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="reputation" className={errorExistForField("reputation") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("reputation") && <small className="text-danger">{errorsForField("reputation")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("upVote") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>UpVotes</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="upVote" className={errorExistForField("upVote") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("upVote") && <small className="text-danger">{errorsForField("upVote")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("view") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Views</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="view" className={errorExistForField("view") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("view") && <small className="text-danger">{errorsForField("view")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("websiteUrl") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>WebsiteUrl</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="websiteUrl" className={errorExistForField("websiteUrl") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("websiteUrl") && <small className="text-danger">{errorsForField("websiteUrl")}</small>}
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
          </form>
  );
}


const UserEdit = withFormik<Props, UserViewModel>({
    mapPropsToValues: props => {
        let response = new UserViewModel();
		response.setProperties(props.model!.aboutMe,props.model!.accountId,props.model!.age,props.model!.creationDate,props.model!.displayName,props.model!.downVote,props.model!.emailHash,props.model!.id,props.model!.lastAccessDate,props.model!.location,props.model!.reputation,props.model!.upVote,props.model!.view,props.model!.websiteUrl);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<UserViewModel> = { };

	  if(values.creationDate == undefined) {
                errors.creationDate = "Required"
                    }if(values.displayName == '') {
                errors.displayName = "Required"
                    }if(values.downVote == 0) {
                errors.downVote = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.lastAccessDate == undefined) {
                errors.lastAccessDate = "Required"
                    }if(values.reputation == 0) {
                errors.reputation = "Required"
                    }if(values.upVote == 0) {
                errors.upVote = "Required"
                    }if(values.view == 0) {
                errors.view = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new UserMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Users +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.UserClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'UserEdit', 
  })(UserEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface UserEditComponentProps
  {
     match:IMatch;
  }

  interface UserEditComponentState
  {
      model?:UserViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class UserEditComponent extends React.Component<UserEditComponentProps, UserEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.UserClientResponseModel;
            
            console.log(response);

			let mapper = new UserMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<UserEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>96a5af0f7e3f44862239a79cefef9f34</Hash>
</Codenesium>*/