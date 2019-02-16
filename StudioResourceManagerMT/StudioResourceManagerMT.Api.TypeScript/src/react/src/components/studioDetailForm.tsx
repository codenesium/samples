import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import StudioMapper from '../mapping/studioMapper';
import StudioViewModel from '../viewmodels/studioViewModel';

interface Props {
    model?:StudioViewModel
}

const StudioDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
				 <div className="form-group row">
					<label htmlFor="address1" className={"col-sm-2 col-form-label"}>Address1</label>
					<div className="col-sm-12">
						{model.model!.address1}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="address2" className={"col-sm-2 col-form-label"}>Address2</label>
					<div className="col-sm-12">
						{model.model!.address2}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="city" className={"col-sm-2 col-form-label"}>City</label>
					<div className="col-sm-12">
						{model.model!.city}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="id" className={"col-sm-2 col-form-label"}>Id</label>
					<div className="col-sm-12">
						{model.model!.id}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="isDeleted" className={"col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
						{model.model!.isDeleted}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="name" className={"col-sm-2 col-form-label"}>Name</label>
					<div className="col-sm-12">
						{model.model!.name}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="province" className={"col-sm-2 col-form-label"}>Province</label>
					<div className="col-sm-12">
						{model.model!.province}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="tenantId" className={"col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
						{model.model!.tenantId}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="website" className={"col-sm-2 col-form-label"}>Website</label>
					<div className="col-sm-12">
						{model.model!.website}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="zip" className={"col-sm-2 col-form-label"}>Zip</label>
					<div className="col-sm-12">
						{model.model!.zip}
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

  interface StudioDetailComponentProps
  {
     match:IMatch;
  }

  interface StudioDetailComponentState
  {
      model?:StudioViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class StudioDetailComponent extends React.Component<StudioDetailComponentProps, StudioDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'studios/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.StudioClientResponseModel;
            
			let mapper = new StudioMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.StudioClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<StudioDetailDisplay model={this.state.model} />);
        } 
        else if (this.state.errorOccurred) {
            return (<div>{this.state.errorMessage}</div>);
        }
        else {
            return (<div></div>);   
        }
    }
}

/*<Codenesium>
    <Hash>da6f96039a54a21930f04b2e4611d462</Hash>
</Codenesium>*/