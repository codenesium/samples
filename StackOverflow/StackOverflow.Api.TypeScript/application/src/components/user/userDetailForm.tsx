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
                  onClick={(e) => { model.history.push(ClientRoutes.Users + '/edit/' + model.model!.id)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="aboutMe" className={"col-sm-2 col-form-label"}>AboutMe</label>
							<div className="col-sm-12">
								{String(model.model!.aboutMe)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="accountId" className={"col-sm-2 col-form-label"}>AccountId</label>
							<div className="col-sm-12">
								{String(model.model!.accountId)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="age" className={"col-sm-2 col-form-label"}>Age</label>
							<div className="col-sm-12">
								{String(model.model!.age)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creationDate" className={"col-sm-2 col-form-label"}>CreationDate</label>
							<div className="col-sm-12">
								{String(model.model!.creationDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="displayName" className={"col-sm-2 col-form-label"}>DisplayName</label>
							<div className="col-sm-12">
								{String(model.model!.displayName)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="downVote" className={"col-sm-2 col-form-label"}>DownVotes</label>
							<div className="col-sm-12">
								{String(model.model!.downVote)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="emailHash" className={"col-sm-2 col-form-label"}>EmailHash</label>
							<div className="col-sm-12">
								{String(model.model!.emailHash)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
							<div className="col-sm-12">
								{String(model.model!.id)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="lastAccessDate" className={"col-sm-2 col-form-label"}>LastAccessDate</label>
							<div className="col-sm-12">
								{String(model.model!.lastAccessDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="location" className={"col-sm-2 col-form-label"}>Location</label>
							<div className="col-sm-12">
								{String(model.model!.location)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="reputation" className={"col-sm-2 col-form-label"}>Reputation</label>
							<div className="col-sm-12">
								{String(model.model!.reputation)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="upVote" className={"col-sm-2 col-form-label"}>UpVotes</label>
							<div className="col-sm-12">
								{String(model.model!.upVote)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="view" className={"col-sm-2 col-form-label"}>Views</label>
							<div className="col-sm-12">
								{String(model.model!.view)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="websiteUrl" className={"col-sm-2 col-form-label"}>WebsiteUrl</label>
							<div className="col-sm-12">
								{String(model.model!.websiteUrl)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     id:number;
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

        axios.get(Constants.ApiEndpoint + ApiRoutes.Users + '/' + this.props.match.params.id,
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
    <Hash>3e935229197b807414852558d0c9d74e</Hash>
</Codenesium>*/