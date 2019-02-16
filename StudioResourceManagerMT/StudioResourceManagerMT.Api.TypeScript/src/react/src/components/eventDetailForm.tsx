import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import EventMapper from '../mapping/eventMapper';
import EventViewModel from '../viewmodels/eventViewModel';

interface Props {
    model?:EventViewModel
}

const EventDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
				 <div className="form-group row">
					<label htmlFor="actualEndDate" className={"col-sm-2 col-form-label"}>ActualEndDate</label>
					<div className="col-sm-12">
						{model.model!.actualEndDate}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="actualStartDate" className={"col-sm-2 col-form-label"}>ActualStartDate</label>
					<div className="col-sm-12">
						{model.model!.actualStartDate}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="billAmount" className={"col-sm-2 col-form-label"}>BillAmount</label>
					<div className="col-sm-12">
						{model.model!.billAmount}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="eventStatusId" className={"col-sm-2 col-form-label"}>EventStatusId</label>
					<div className="col-sm-12">
						{model.model!.eventStatusId}
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
					<label htmlFor="scheduledEndDate" className={"col-sm-2 col-form-label"}>ScheduledEndDate</label>
					<div className="col-sm-12">
						{model.model!.scheduledEndDate}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="scheduledStartDate" className={"col-sm-2 col-form-label"}>ScheduledStartDate</label>
					<div className="col-sm-12">
						{model.model!.scheduledStartDate}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="studentNote" className={"col-sm-2 col-form-label"}>StudentNote</label>
					<div className="col-sm-12">
						{model.model!.studentNote}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="teacherNote" className={"col-sm-2 col-form-label"}>TeacherNote</label>
					<div className="col-sm-12">
						{model.model!.teacherNote}
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

  interface EventDetailComponentProps
  {
     match:IMatch;
  }

  interface EventDetailComponentState
  {
      model?:EventViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class EventDetailComponent extends React.Component<EventDetailComponentProps, EventDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'events/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.EventClientResponseModel;
            
			let mapper = new EventMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.EventClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<EventDetailDisplay model={this.state.model} />);
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
    <Hash>85b6a3f6d6a3d24502739887f7dddc1d</Hash>
</Codenesium>*/