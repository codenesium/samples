import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import UserMapper from './userMapper';
import UserViewModel from './userViewModel';

interface Props {
	history:any;
    model?:UserViewModel
}

const UserDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Users + '/edit/' + model.model!.userId)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="bioImgUrl" className={"col-sm-2 col-form-label"}>Bio_img_url</label>
							<div className="col-sm-12">
								{String(model.model!.bioImgUrl)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="birthday" className={"col-sm-2 col-form-label"}>Birthday</label>
							<div className="col-sm-12">
								{String(model.model!.birthday)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="contentDescription" className={"col-sm-2 col-form-label"}>Content_description</label>
							<div className="col-sm-12">
								{String(model.model!.contentDescription)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="email" className={"col-sm-2 col-form-label"}>Email</label>
							<div className="col-sm-12">
								{String(model.model!.email)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="fullName" className={"col-sm-2 col-form-label"}>Full_name</label>
							<div className="col-sm-12">
								{String(model.model!.fullName)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="headerImgUrl" className={"col-sm-2 col-form-label"}>Header_img_url</label>
							<div className="col-sm-12">
								{String(model.model!.headerImgUrl)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="interest" className={"col-sm-2 col-form-label"}>Interest</label>
							<div className="col-sm-12">
								{String(model.model!.interest)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="locationLocationId" className={"col-sm-2 col-form-label"}>Location_location_id</label>
							<div className="col-sm-12">
								{model.model!.locationLocationIdNavigation!.toDisplay()}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="password" className={"col-sm-2 col-form-label"}>Password</label>
							<div className="col-sm-12">
								{String(model.model!.password)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="phoneNumber" className={"col-sm-2 col-form-label"}>Phone_number</label>
							<div className="col-sm-12">
								{String(model.model!.phoneNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="privacy" className={"col-sm-2 col-form-label"}>Privacy</label>
							<div className="col-sm-12">
								{String(model.model!.privacy)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="username" className={"col-sm-2 col-form-label"}>Username</label>
							<div className="col-sm-12">
								{String(model.model!.username)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="website" className={"col-sm-2 col-form-label"}>Website</label>
							<div className="col-sm-12">
								{String(model.model!.website)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     userId:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface UserDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface UserDetailComponentState
  {
      model?:UserViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class UserDetailComponent extends React.Component<UserDetailComponentProps, UserDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.props.match.params.userId,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.UserClientResponseModel;
            
			let mapper = new UserMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
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
            return (<UserDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>bb255bee587066b73a728b9ebb680e0d</Hash>
</Codenesium>*/