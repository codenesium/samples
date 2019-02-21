import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import FollowerViewModel from './followerViewModel';
import FollowerMapper from './followerMapper';

interface Props {
    model?:FollowerViewModel
}

  const FollowerEditDisplay = (props: FormikProps<FollowerViewModel>) => {

   let status = props.status as UpdateResponse<Api.FollowerClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof FollowerViewModel]  && props.errors[name as keyof FollowerViewModel]) {
            response += props.errors[name as keyof FollowerViewModel];
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
                        <label htmlFor="name" className={errorExistForField("blocked") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Blocked</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="blocked" className={errorExistForField("blocked") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("blocked") && <small className="text-danger">{errorsForField("blocked")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dateFollowed") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Date_followed</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dateFollowed" className={errorExistForField("dateFollowed") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateFollowed") && <small className="text-danger">{errorsForField("dateFollowed")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("followRequestStatu") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Follow_request_status</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="followRequestStatu" className={errorExistForField("followRequestStatu") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("followRequestStatu") && <small className="text-danger">{errorsForField("followRequestStatu")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("followedUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Followed_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="followedUserId" className={errorExistForField("followedUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("followedUserId") && <small className="text-danger">{errorsForField("followedUserId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("followingUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Following_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="followingUserId" className={errorExistForField("followingUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("followingUserId") && <small className="text-danger">{errorsForField("followingUserId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("muted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Muted</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="muted" className={errorExistForField("muted") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("muted") && <small className="text-danger">{errorsForField("muted")}</small>}
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


const FollowerEdit = withFormik<Props, FollowerViewModel>({
    mapPropsToValues: props => {
        let response = new FollowerViewModel();
		response.setProperties(props.model!.blocked,props.model!.dateFollowed,props.model!.followRequestStatu,props.model!.followedUserId,props.model!.followingUserId,props.model!.id,props.model!.muted);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<FollowerViewModel> = { };

	  if(values.blocked == '') {
                errors.blocked = "Required"
                    }if(values.dateFollowed == undefined) {
                errors.dateFollowed = "Required"
                    }if(values.followRequestStatu == '') {
                errors.followRequestStatu = "Required"
                    }if(values.followedUserId == 0) {
                errors.followedUserId = "Required"
                    }if(values.followingUserId == 0) {
                errors.followingUserId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.muted == '') {
                errors.muted = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new FollowerMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Followers +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.FollowerClientRequestModel>;
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
  
    displayName: 'FollowerEdit', 
  })(FollowerEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface FollowerEditComponentProps
  {
     match:IMatch;
  }

  interface FollowerEditComponentState
  {
      model?:FollowerViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class FollowerEditComponent extends React.Component<FollowerEditComponentProps, FollowerEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Followers + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.FollowerClientResponseModel;
            
            console.log(response);

			let mapper = new FollowerMapper();

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
            return (<FollowerEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>83ce287b5a9cd90b2e1d9265a3660958</Hash>
</Codenesium>*/