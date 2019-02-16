import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import SpaceMapper from '../mapping/spaceMapper';
import SpaceViewModel from '../viewmodels/spaceViewModel';

interface Props {
    model?:SpaceViewModel
}

const SpaceDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
				 <div className="form-group row">
					<label htmlFor="description" className={"col-sm-2 col-form-label"}>Description</label>
					<div className="col-sm-12">
						{model.model!.description}
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
					<label htmlFor="tenantId" className={"col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
						{model.model!.tenantId}
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

  interface SpaceDetailComponentProps
  {
     match:IMatch;
  }

  interface SpaceDetailComponentState
  {
      model?:SpaceViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class SpaceDetailComponent extends React.Component<SpaceDetailComponentProps, SpaceDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'spaces/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SpaceClientResponseModel;
            
			let mapper = new SpaceMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.SpaceClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<SpaceDetailDisplay model={this.state.model} />);
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
    <Hash>72c9d9372c7bcbea41742ea8a6bc650d</Hash>
</Codenesium>*/