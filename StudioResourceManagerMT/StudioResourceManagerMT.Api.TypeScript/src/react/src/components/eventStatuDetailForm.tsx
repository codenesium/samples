import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import EventStatuMapper from '../mapping/eventStatuMapper';
import EventStatuViewModel from '../viewmodels/eventStatuViewModel';

interface Props {
    model?:EventStatuViewModel
}

const EventStatuDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
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

  interface EventStatuDetailComponentProps
  {
     match:IMatch;
  }

  interface EventStatuDetailComponentState
  {
      model?:EventStatuViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class EventStatuDetailComponent extends React.Component<EventStatuDetailComponentProps, EventStatuDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'eventstatus/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.EventStatuClientResponseModel;
            
			let mapper = new EventStatuMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.EventStatuClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<EventStatuDetailDisplay model={this.state.model} />);
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
    <Hash>ceb1df35a77f482f21a4341e5d1264f6</Hash>
</Codenesium>*/