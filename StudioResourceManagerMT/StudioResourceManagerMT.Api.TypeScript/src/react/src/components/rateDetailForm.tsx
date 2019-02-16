import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import RateMapper from '../mapping/rateMapper';
import RateViewModel from '../viewmodels/rateViewModel';

interface Props {
    model?:RateViewModel
}

const RateDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
			 				
				 <div className="form-group row">
					<label htmlFor="amountPerMinute" className={"col-sm-2 col-form-label"}>AmountPerMinute</label>
					<div className="col-sm-12">
						{model.model!.amountPerMinute}
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
					<label htmlFor="teacherId" className={"col-sm-2 col-form-label"}>TeacherId</label>
					<div className="col-sm-12">
						{model.model!.teacherId}
					</div>
				</div>

			   				
				 <div className="form-group row">
					<label htmlFor="teacherSkillId" className={"col-sm-2 col-form-label"}>TeacherSkillId</label>
					<div className="col-sm-12">
						{model.model!.teacherSkillId}
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

  interface RateDetailComponentProps
  {
     match:IMatch;
  }

  interface RateDetailComponentState
  {
      model?:RateViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class RateDetailComponent extends React.Component<RateDetailComponentProps, RateDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'rates/' + this.props.match.params.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.RateClientResponseModel;
            
			let mapper = new RateMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.RateClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<RateDetailDisplay model={this.state.model} />);
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
    <Hash>9147a63146be8346954e1ac1316c0352</Hash>
</Codenesium>*/